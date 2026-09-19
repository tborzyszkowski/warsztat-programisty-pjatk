# 02. Struktura materiałów i zasady oddawania

## Cel

Student potrafi ułożyć małą pracę tak, aby inna osoba mogła ją znaleźć, uruchomić i ocenić
bez rozmowy na żywo. Struktura katalogów jest częścią jakości, a nie dekoracją.

## Dwa repozytoria: kursowe i studenta

Repozytorium kursowe zawiera materiały do zajęć. Student korzysta z niego jako źródła
instrukcji i przykładów, ale nie oddaje do niego swoich prac.

Każdy student tworzy własne repozytorium na GitHubie lub GitLabie. To w nim przechowuje
rozwiązania, historię commitów i README potrzebne do oceny. Repozytorium może być publiczne
albo prywatne, zgodnie z ustaleniami prowadzącego.

## Proponowana struktura własnego repozytorium

```text
repozytorium-studenta/
|-- README.md
|-- src/
|   |-- 01-organizacja/
|   |-- 02-debugowanie/
|   `-- ...
|-- zadania/
|   |-- 01-nazwa-zadania/
|   |   |-- README.md
|   |   |-- src/
|   |   `-- tests/
|   `-- ...
|-- docs/
|   `-- notatki.md
`-- .gitignore
```

Materiały z pierwszych zajęć są w [katalogu `src/01-organizacja`](../README.md) repozytorium
kursowego. Własne repozytorium powinno mieć krótkie, numerowane i zrozumiałe nazwy katalogów.

## Co powinien zawierać katalog zadania

| Element | Odpowiada na pytanie |
| --- | --- |
| `README.md` | Co było celem i jak uruchomić rezultat? |
| `src/` lub pliki z kodem | Gdzie jest implementacja? |
| `tests/` | Jak sprawdzono działanie? |
| `diagramy/` | Jaki przepływ lub model warto zobaczyć? |
| `.gitignore` | Czego nie dodajemy do historii? |

Nie każde zadanie musi mieć wszystkie katalogi. Nie tworzymy pustych folderów tylko dlatego,
że widzieliśmy je w szablonie. Struktura ma pomagać w nawigacji.

## Minimalny README pracy

```markdown
# Nazwa zadania

## Cel
Jedno zdanie opisujące rezultat.

## Uruchomienie
1. Zainstaluj wymagane narzędzie.
2. Uruchom polecenie ...

## Sprawdzenie
- przypadek zwykły: ...
- przypadek brzegowy: ...
- oczekiwany rezultat: ...

## Zakres oddania
- [x] kod
- [x] instrukcja
- [x] testy lub opis kontroli
```

Instrukcja powinna zawierać konkretne polecenia, ale nie powinna zakładać, że odbiorca zna
lokalną konfigurację autora. Jeśli wymagane jest ustawienie zmiennej środowiskowej, trzeba
podać jej nazwę i opisać, skąd legalnie uzyskać wartość.

## Zasady oddawania prac z własnego repozytorium

1. Utwórz własne repozytorium na GitHubie lub GitLabie i nadaj mu nazwę związaną z kursem.
2. Oddaj link do własnego repozytorium oraz, jeśli praca jest na osobnej gałęzi, link do tej gałęzi.
3. W opisie oddania wskaż commit lub tag, który należy ocenić. PR/MR do repozytorium kursowego nie jest wymagany.
4. Opisz, co zostało zrobione i czego nie udało się zrobić.
5. Dodaj instrukcję uruchomienia od czystego katalogu.
6. Wymień wykonane kontrole i ich wyniki.
7. Odpowiedz na pytania z treści zadania w README.
8. Usuń pliki generowane, logi i dane lokalne, jeśli nie są częścią zadania.
9. Nie poprawiaj historii przez usuwanie cudzych commitów.

## Checklista jakości przed oddaniem

### Treść

- [ ] Nazwa zadania i cel są jasne.
- [ ] README opisuje instalację, uruchomienie i przykładowy wynik.
- [ ] Użyte pojęcia są wyjaśnione przy pierwszym użyciu.

### Kod

- [ ] Kod jest sformatowany zgodnie z ustaleniami grupy.
- [ ] Nazwy zmiennych i funkcji opisują ich role.
- [ ] Nie ma zakomentowanego kodu, który udaje rozwiązanie.
- [ ] Błędy danych wejściowych są obsłużone albo jawnie opisane.

### Weryfikacja

- [ ] Uruchomiłem przykład z README.
- [ ] Sprawdziłem przypadek zwykły i brzegowy.
- [ ] Wiem, co oznacza wynik kontroli.
- [ ] `git status` pokazuje tylko pliki, które chcę oddać.

### Higiena repozytorium

- [ ] Brak sekretów i danych osobowych.
- [ ] Brak katalogów IDE i plików tymczasowych.
- [ ] Linki w README prowadzą do istniejących plików.

## Zadanie dla studenta

Utwórz w swoim repozytorium katalog `zadania/01-checklista` z:

- plikiem `README.md` według szablonu powyżej,
- jednym plikiem `wynik.txt` zawierającym przykładowy rezultat,
- sekcją "Sprawdzenie" z trzema przypadkami,
- checklistą zaznaczoną tylko w punktach, które rzeczywiście wykonałeś.

Następnie wykonaj lokalnie instrukcję z README osoby siedzącej obok. Nie udzielaj jej
ustnych wyjaśnień, dopóki nie odnotuje pierwszego miejsca, w którym utknęła.

Utwórz repozytorium `warsztat-programisty-01` na GitHubie lub GitLabie, dodaj do niego
przygotowany katalog, wykonaj commit i wypchnij zmiany. Do oddania przekaż link do własnego
repozytorium oraz identyfikator commitu. Nie twórz PR/MR do repozytorium kursowego.

### Rozwiązanie i wyjaśnienie

Przykładowy katalog:

```text
zadania/01-checklista/
|-- README.md
`-- wynik.txt
```

Przykładowy plik `README.md`:

```markdown
# Sprawdzenie temperatury

## Cel
Pokazać wynik dla wartości 20 stopni Celsjusza.

## Uruchomienie
Otwórz plik `wynik.txt` i porównaj go z sekcją "Sprawdzenie".

## Sprawdzenie
- zwykły: 20 -> 20 stopni Celsjusza
- brzegowy: 0 -> 0 stopni Celsjusza
- niepoprawny: brak wartości -> przypadek opisany jako "brak danych"

## Zakres oddania
- [x] opis celu
- [x] instrukcja
- [x] trzy przypadki kontroli
```

Rozwiązanie jest minimalne, ale kompletne: odbiorca wie, co ma sprawdzić, a autor nie udaje,
że test automatyczny istnieje, gdy wykonano tylko kontrolę ręczną.

## Diagram

```mermaid
flowchart TD
    A[Treść zadania] --> B[README i struktura]
    B --> C[Implementacja]
    C --> D[Uruchomienie]
    D --> E[Przypadki kontroli]
    E --> F[Checklista]
    F --> G[Link do własnego repozytorium]
```

Źródło diagramu: [checklista oddania](diagramy/checklista-oddania.mmd).
