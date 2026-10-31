# 05. Dziwne sytuacje: naprawianie historii i odzyskiwanie zmian

## Cel laboratorium

Po wykonaniu tematu student potrafi:

- naprawić pomyłkowy `push` z niepoprawnymi plikami,
- odróżnić cofnięcie zmiany od usunięcia jej z historii,
- zareagować na sekret opublikowany w repozytorium,
- przepisać własną historię za pomocą interaktywnego rebase,
- odzyskać utracony commit z refloga,
- użyć `bisect` do znalezienia commita wprowadzającego błąd,
- zastosować `cherry-pick` do przeniesienia wybranej poprawki.

Ćwiczenia wykonuj w osobnym, testowym repozytorium. Przepisywanie historii i
`push --force-with-lease` zmieniają historię widoczną dla innych osób. Przed każdą
operacją sprawdź `git status`, nazwę gałęzi i kopię zapasową.

## Najważniejsze rozróżnienie: cofnięcie a usunięcie z historii

`git revert` tworzy nowy commit, który odwraca efekt wcześniejszego commita. Jest
bezpieczny na współdzielonej gałęzi, bo nie zmienia istniejących identyfikatorów commitów.

`git reset` przesuwa lokalny wskaźnik gałęzi. Wariant `--soft` zachowuje zmiany w
indeksie, `--mixed` (domyślny) pozostawia je w katalogu roboczym, a `--hard` usuwa
niezatwierdzone zmiany z katalogu roboczego. `reset` nadaje się przede wszystkim do
własnej, jeszcze niewysłanej historii.

Nawet jeśli usuniesz plik z najnowszego commita, nie znika on ze starszego commita.
Do usunięcia pliku z całej historii potrzebujesz narzędzia do przepisywania historii,
a po publikacji także wymuszonego wysłania nowej historii.

## 1. Pomyłkowy push z niepoprawnymi plikami

### O co chodzi?

Do commita trafił plik, którego nie powinno być w repozytorium, na przykład binarne
artefakty kompilacji, archiwum, katalog `.vs` albo duży plik generowany. Samo
skasowanie pliku i kolejny `push` poprawia stan najnowszej wersji, ale nie usuwa
pliku ze starszego commita.

Najpierw ustal, czy błąd dotyczy tylko najnowszego commita i czy inni zdążyli pobrać
gałąź. Na współdzielonej gałęzi domyślnie użyj `revert`; nie przepisuj historii bez
uzgodnienia z zespołem.

### Kiedy stosować?

- **`git revert`**: gdy commit jest już publiczny albo inni mogli go pobrać.
- **`git reset` i ponowny push**: gdy commit jest wyłącznie Twój i chcesz poprawić
  jego zawartość przed udostępnieniem.
- **`git filter-repo`**: gdy plik ma zniknąć ze wszystkich commitów, na przykład
  dlatego, że jest duży lub narusza zasady repozytorium.

### Ćwiczenie: zły binarny plik po pushu

1. Utwórz testowe repozytorium i plik `README.md`:

   ```text
   mkdir git-naprawa
   cd git-naprawa
   git init -b main
   "Instrukcja projektu" | Out-File -Encoding utf8 README.md
   git add README.md
   git commit -m "Dodaj instrukcje"
   ```

2. Zasymuluj pomyłkę, tworząc plik `bin/app.dll`, dodając go i wykonując commit:

   ```text
   New-Item -ItemType Directory bin
   "To jest artefakt testowy" | Out-File -Encoding utf8 bin/app.dll
   git add .
   git commit -m "Dodaj instrukcje i artefakt"
   git log --oneline --stat -2
   ```

3. Zabezpiecz repozytorium przed powtórką. Dopisz `bin/`, `obj/`, `.vs/` i
   `*.dll` do `.gitignore`, a następnie sprawdź:

   ```text
   git status --short
   git check-ignore -v bin/app.dll
   ```

4. Jeśli ten commit byłby już na współdzielonym `main`, usuń plik z bieżącego stanu
   i utwórz commit odwracający pomyłkę:

   ```text
   git rm --cached bin/app.dll
   git commit -m "Usuń przypadkowy artefakt"
   git push origin main
   ```

   `--cached` usuwa plik z indeksu, ale nie z dysku; jest przydatne, jeśli lokalny
   artefakt nadal jest potrzebny do pracy. W tym ćwiczeniu można też użyć `git rm`
   bez `--cached`.

5. Jeśli commit nie był jeszcze udostępniony i chcesz, aby wyglądał tak, jakby
   nigdy nie zawierał pliku, cofnij ostatni commit bez utraty zmian:

   ```text
   git reset --soft HEAD~1
   git restore --staged bin/app.dll
   git rm -f bin/app.dll
   git add .gitignore README.md
   git commit -m "Dodaj tylko instrukcje"
   ```

6. Gdy zła historia była już wysłana, a zespół uzgodnił jej przepisanie, wykonaj
   najpierw kopię referencji i sprawdź różnicę:

   ```text
   git branch backup-przed-naprawa
   git log --oneline --all --decorate
   ```

   Do usunięcia pliku z całej historii użyj zainstalowanego `git-filter-repo`:

   ```text
   git filter-repo --path bin/app.dll --invert-paths
   git push --force-with-lease origin main
   ```

   Po takim pushu współpracownicy muszą uzgodnić sposób ponownego sklonowania lub
   zsynchronizowania repozytorium. Nie używaj bezmyślnie `git pull`; stara historia
   może zostać ponownie wypchnięta.

7. Sprawdź rezultat:

   ```text
   git log --all -- bin/app.dll
   git status
   ```

   Pusty wynik pierwszej komendy oznacza, że plik nie występuje w widocznej historii
   tej kopii. Usługi hostingowe mogą mieć własne cache, kopie zapasowe lub pull
   requesty, więc usunięcie z historii Git nie jest obietnicą natychmiastowego
   usunięcia każdej kopii poza repozytorium.

## 2. Sekret przypadkowo w repozytorium

### O co chodzi?

Klucz prywatny, token, hasło lub certyfikat należy traktować jako ujawniony od chwili
jego zapisania w repozytorium, nawet jeśli commit był lokalny albo plik później usunięto.
Git przechowuje obiekty w historii, a hosting może mieć kopie w cache, forkach,
pull requestach i logach CI.

Usunięcie sekretu z pliku nie unieważnia go. Najpierw odetnij możliwość użycia
ujawnionej wartości, potem usuń ją z historii i sprawdź, gdzie jeszcze mogła trafić.

### Kiedy stosować?

Zawsze wykonaj poniższą kolejność przy prawdziwym sekrecie:

1. **Unieważnij lub obróć sekret** u dostawcy (token revoke/rotate, zmiana hasła,
   wymiana klucza i certyfikatu).
2. **Ogranicz skutki**: sprawdź logi użycia, zakres uprawnień i poinformuj osoby,
   które mogły pobrać repozytorium.
3. **Usuń wartość z plików i historii** za pomocą `git-filter-repo` albo procedury
   hostingu.
4. **Wymuś bezpieczną synchronizację** i dodaj regułę `.gitignore` oraz mechanizm
   sekretów poza repozytorium.

Nie wpisuj prawdziwego sekretu do ćwiczenia, zgłoszenia, komunikatu commita ani
historii poleceń.

### Ćwiczenie: token w commicie i pełna reakcja

1. W testowym repozytorium utwórz plik z wartością udającą sekret:

   ```text
   "ACCESS_TOKEN=demo-token-do-cwiczen" | Out-File -Encoding utf8 .env
   git add .env
   git commit -m "Dodaj konfiguracje"
   git log --oneline --all
   ```

2. Zasymuluj unieważnienie: zanotuj, że wartość `demo-token-do-cwiczen` trzeba
   unieważnić u dostawcy. W prawdziwym incydencie zrób to **przed** czyszczeniem
   historii, ponieważ samo przepisywanie historii nie blokuje starego tokenu.

3. Usuń plik z bieżącej wersji i zabezpiecz jego nazwę:

   ```text
   git rm --cached .env
   ".env" | Add-Content .gitignore
   git add .gitignore
   git commit -m "Nie śledź lokalnej konfiguracji"
   ```

   W pliku `.gitignore` wpis powinien brzmieć `.env` bez początkowej spacji.
   Sprawdź go przez `git check-ignore -v .env`.

4. Usuń plik ze wszystkich commitów. Dla pojedynczego pliku użyj:

   ```text
   git branch backup-przed-czyszczeniem
   git filter-repo --path .env --invert-paths
   ```

   Jeśli sekret występuje w wielu plikach lub jako konkretny tekst, zastosuj
   `--replace-text` z plikiem zawierającym wzorzec i zamiennikiem. Nie zapisuj
   prawdziwej wartości w materiale dydaktycznym ani w publicznym logu poleceń.

5. Zweryfikuj lokalną kopię:

   ```text
   git log --all -- .env
   git grep -n "demo-token-do-cwiczen" $(git rev-list --all) 2>$null
   git status
   ```

6. Po uzgodnieniu z zespołem wypchnij przepisane gałęzie:

   ```text
   git push --force-with-lease origin main
   ```

   Następnie poinformuj współpracowników, że ich stare klony zawierają ujawnioną
   historię. Najbezpieczniej jest usunąć klon i wykonać świeży `git clone`; alternatywą
   jest dokładnie uzgodniona synchronizacja z nowym `origin/main`.

7. Sprawdź hosting: usuń lub zamknij stare pull requesty zawierające sekret,
   sprawdź forki i artefakty CI, a w razie potrzeby poproś administratora hostingu
   o czyszczenie cache. Rotację sekretu wykonuj ponownie, jeśli mógł zostać
   skopiowany po pierwszym unieważnieniu.

## 3. Interaktywne przebudowywanie historii

### O co chodzi?

`git rebase -i` otwiera listę commitów i pozwala zmienić ich kolejność, połączyć je,
zmienić komunikat, zatrzymać się do edycji plików albo usunąć commit. Powstają nowe
identyfikatory commitów, dlatego tej techniki używaj przed publikacją albo wyłącznie
na własnej gałęzi za zgodą zespołu.

Najważniejsze polecenia w planie rebase:

- `pick` — zachowaj commit,
- `reword` — zmień tylko komunikat,
- `edit` — zatrzymaj się i popraw zawartość,
- `squash` — połącz z poprzednim i połącz komunikaty,
- `fixup` — połącz z poprzednim i odrzuć komunikat bieżącego,
- `drop` — usuń commit.

### Kiedy stosować?

Użyj rebase, aby uporządkować własną gałąź przed PR-em: połączyć drobne poprawki,
usunąć przypadkowy commit, poprawić opis albo zmienić kolejność logicznych zmian.
Nie używaj go do cichej zmiany wspólnej gałęzi.

### Ćwiczenie: squashing, edycja, usuwanie i zmiana kolejności

1. Utwórz trzy commity:

   ```text
   "Pierwsza wersja" | Out-File -Encoding utf8 historia.txt
   git add historia.txt
   git commit -m "Dodaj plik"
   "Druga linia" | Add-Content historia.txt
   git add historia.txt
   git commit -m "Drobna poprawka"
   "Ta linia jest pomylka" | Add-Content historia.txt
   git add historia.txt
   git commit -m "Debugowanie"
   ```

2. Obejrzyj plan ostatnich trzech commitów i uruchom interaktywny rebase:

   ```text
   git log --oneline -3
   git rebase -i HEAD~3
   ```

3. W edytorze zamień `pick` drugiego commita na `squash`, a przy trzecim użyj
   `edit`. Zapisz plik planu. Git poprosi o połączenie komunikatów — zostaw opis
   jednej logicznej zmiany.

4. Po zatrzymaniu na `edit` usuń błędną linię, sprawdź diff i popraw commit:

   ```text
   git restore --source=HEAD~1 -- historia.txt
   # albo edytuj plik ręcznie, zostawiając poprawną treść
   git add historia.txt
   git commit --amend --no-edit
   git rebase --continue
   ```

   Jeśli rebase nie ma już konfliktów, sprawdź:

   ```text
   git log --oneline --graph -3
   git show --stat HEAD
   ```

5. Przećwicz zmianę kolejności na kopii gałęzi. W planie rebase zamień miejscami
   dwa commity, ale zatrzymaj się, gdy Git zgłosi konflikt. Rozwiąż go tak jak
   konflikt podczas zwykłego rebase: popraw plik, `git add`, `git rebase --continue`.
   Operację można przerwać przez `git rebase --abort`.

## 4. Odzyskiwanie danych i naprawianie błędów

### O co chodzi?

Dopóki obiekty nie zostaną usunięte przez sprzątanie repozytorium, reflog często
przechowuje poprzednie położenia lokalnych wskaźników. Dzięki temu można odnaleźć
commit po błędnym `reset`, rebase lub usunięciu gałęzi.

### Kiedy stosować?

Sięgnij po `reflog`, gdy znasz przybliżony czas utraty pracy, ale nie widzisz commita
przez `git log`. Nie zakładaj, że reflog jest kopią zapasową: zwykle jest lokalny,
ma ograniczony czas przechowywania i nie istnieje na świeżym klonie.

### Ćwiczenie: odzyskanie commita po reset

1. Utwórz i zatwierdź zmianę:

   ```text
   "Wazna notatka" | Out-File -Encoding utf8 odzysk.txt
   git add odzysk.txt
   git commit -m "Dodaj wazna notatke"
   ```

2. Zasymuluj błąd:

   ```text
   git reset --hard HEAD~1
   git log --oneline
   ```

3. Odnajdź poprzedni commit:

   ```text
   git reflog --date=local
   ```

   Odczytaj wpis sprzed `reset`, na przykład `HEAD@{1}`, ale użyj rzeczywistego
   identyfikatora wyświetlonego w Twoim repozytorium.

4. Utwórz bezpieczną gałąź odzyskiwania i sprawdź plik:

   ```text
   git switch -c odzyskane-dane IDENTYFIKATOR
   git show --stat
   ```

5. Jeśli commit jest właściwy, połącz go z pracą albo przenieś wybraną zmianę przez
   `cherry-pick`. Nie wykonuj kolejnego `reset --hard`, dopóki nie masz kopii
   odnalezionego identyfikatora.

## 5. Debugowanie kodu za pomocą historii

### O co chodzi?

Historia odpowiada nie tylko na pytanie „kto zmienił linię”, ale także „który commit
wprowadził błąd”. `git blame` wskazuje commit odpowiedzialny za poszczególne linie,
`git show` pokazuje jego zmianę, a `git bisect` prowadzi wyszukiwanie binarne między
dobrym i złym stanem.

### Kiedy stosować?

Użyj `blame`, gdy potrzebujesz kontekstu lub powiązanego zadania. Użyj `bisect`, gdy
masz powtarzalny test, który jednoznacznie zwraca „dobrze” albo „źle”, a zakres
podejrzanych commitów jest większy niż jeden.

### Ćwiczenie: `bisect` znajduje regresję

1. Utwórz plik `program.txt` z wartością `OK` i wykonaj commit:

   ```text
   "OK" | Out-File -Encoding utf8 program.txt
   git add program.txt
   git commit -m "Stan dzialajacy"
   ```

2. Wykonaj dwa poprawne commity, a następnie jeden błędny:

   ```text
   "OK 2" | Out-File -Encoding utf8 program.txt
   git add program.txt; git commit -m "Rozszerz wynik"
   "BLAD" | Out-File -Encoding utf8 program.txt
   git add program.txt; git commit -m "Przypadkowo zepsuj wynik"
   ```

3. Uruchom bisect, oznaczając bieżący stan jako zły i pierwszy commit jako dobry:

   ```text
   git bisect start
   git bisect bad
   git bisect good HEAD~3
   ```

4. Po każdym przełączeniu sprawdź plik. Jeśli zawiera `BLAD`, wykonaj `git bisect bad`;
   jeśli nie, wykonaj `git bisect good`. Git zawęzi zakres do commita wprowadzającego
   problem.

5. Odczytaj znalezioną zmianę:

   ```text
   git show
   git bisect reset
   ```

   `bisect reset` przywraca gałąź do stanu sprzed diagnozy. Dopiero teraz napraw
   problem zwykłym commitem lub przygotuj poprawkę.

## 6. `cherry-pick`: przegląd przypadków

### O co chodzi?

`git cherry-pick IDENTYFIKATOR` kopiuje zmianę z istniejącego commita na bieżącą
gałąź, tworząc nowy commit. Nie przenosi całej gałęzi ani jej historii rodziców.

### Kiedy stosować?

- przenieś pojedynczy hotfix z `feature` na `main`,
- zastosuj tę samą, małą poprawkę na dwóch wspieranych wersjach,
- odzyskaj konkretną zmianę z gałęzi, której nie chcesz jeszcze scalać.

Przed użyciem sprawdź, czy commit nie zależy od innych zmian. Przy konflikcie nie
zgaduj: obejrzyj `git status`, popraw pliki, wykonaj `git add`, a potem
`git cherry-pick --continue`. Jeśli decyzja była błędna, użyj
`git cherry-pick --abort`.

### Ćwiczenie: hotfix na dwóch gałęziach

1. Utwórz gałąź `feature/hotfix`, dodaj plik i zapisz identyfikator commita:

   ```text
   git switch -c feature/hotfix
   "Poprawiony komunikat" | Out-File -Encoding utf8 komunikat.txt
   git add komunikat.txt
   git commit -m "Popraw komunikat"
   git log --oneline -1
   ```

2. Wróć na `main` i zastosuj tylko tę zmianę:

   ```text
   git switch main
   git cherry-pick IDENTYFIKATOR
   git log --oneline --graph --all -4
   ```

3. Zasymuluj konflikt, zmieniając ten sam plik na `main` przed kolejnym
   `cherry-pick`. Gdy Git zatrzyma operację:

   ```text
   git status
   # popraw komunikat.txt zgodnie z wymaganiami
   git add komunikat.txt
   git cherry-pick --continue
   ```

4. Jeśli poprawka nie pasuje do tej gałęzi, przećwicz bezpieczne anulowanie:

   ```text
   git cherry-pick --abort
   ```

   Sprawdź `git status` i porównaj `git log` z kopią sprzed operacji.

## Końcowa checklista

- [ ] Przed naprawą wiem, czy gałąź jest współdzielona.
- [ ] Zwykłe wycofanie publicznego błędu robię przez `git revert`.
- [ ] Przed usunięciem sekretu z historii najpierw go unieważniam.
- [ ] Nie przechowuję sekretów w repozytorium i mam reguły `.gitignore`.
- [ ] Przed rebase lub force push mam kopię i używam `--force-with-lease`.
- [ ] Po rebase sprawdziłem log, diff i działanie projektu.
- [ ] Przy odzyskiwaniu sprawdziłem `reflog`, zanim uznałem pracę za utraconą.
- [ ] Po `bisect` wykonałem `git bisect reset`.
- [ ] Przy `cherry-pick` potrafię kontynuować albo anulować operację.
