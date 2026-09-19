# 02. Struktura materialow i zasady oddawania

## Cel

Student potrafi ulozyc mala prace tak, aby inna osoba mogla ja znalezc, uruchomic i ocenic
bez rozmowy na zywo. Struktura katalogow jest czescia jakosci, a nie dekoracja.

## Proponowana struktura repozytorium kursowego

```text
repozytorium-kursowe/
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

W tym repozytorium materialy z pierwszych zajec sa w [katalogu `src/01-organizacja`](../README.md).
Nazwy powinny byc krotkie, numerowane i zrozumiale bez otwierania pliku.

## Co powinien zawierac katalog zadania

| Element | Odpowiada na pytanie |
| --- | --- |
| `README.md` | Co bylo celem i jak uruchomic rezultat? |
| `src/` lub pliki z kodem | Gdzie jest implementacja? |
| `tests/` | Jak sprawdzono dzialanie? |
| `diagramy/` | Jaki przeplyw lub model warto zobaczyc? |
| `.gitignore` | Czego nie dodajemy do historii? |

Nie kazde zadanie musi miec wszystkie katalogi. Nie tworzymy pustych folderow tylko dlatego,
je widzielismy w szablonie. Struktura ma pomagac w nawigacji.

## Minimalny README pracy

```markdown
# Nazwa zadania

## Cel
Jedno zdanie opisujace rezultat.

## Uruchomienie
1. Zainstaluj wymagane narzedzie.
2. Uruchom polecenie ...

## Sprawdzenie
- przypadek zwykly: ...
- przypadek brzegowy: ...
- oczekiwany rezultat: ...

## Zakres oddania
- [x] kod
- [x] instrukcja
- [x] testy lub opis kontroli
```

Instrukcja powinna zawierac konkretne polecenia, ale nie powinna zakladac, ze odbiorca zna
lokalna konfiguracje autora. Jesli wymagane jest ustawienie zmiennej srodowiskowej, trzeba
podac jej nazwe i opisac, skad legalnie uzyskac wartosc.

## Zasady oddawania prac

1. Oddaj link do konkretnej galezi, commitu lub PR/MR, a nie tylko link do profilu.
2. Opisz, co zostalo zrobione i czego nie udalo sie zrobic.
3. Dodaj instrukcje uruchomienia od czystego katalogu.
4. Wymien wykonane kontrole i ich wyniki.
5. Odpowiedz na pytania z tresci zadania w README.
6. Usun pliki generowane, logi i dane lokalne, jesli nie sa czescia zadania.
7. Nie poprawiaj historii przez usuwanie cudzych commitow.

## Checklista jakosci przed oddaniem

### Tresc

- [ ] Nazwa zadania i cel sa jasne.
- [ ] README opisuje instalacje, uruchomienie i przykladowy wynik.
- [ ] Uzyte pojecia sa wyjasnione przy pierwszym uzyciu.

### Kod

- [ ] Kod jest sformatowany zgodnie z ustaleniami grupy.
- [ ] Nazwy zmiennych i funkcji opisuja ich role.
- [ ] Nie ma zakomentowanego kodu, ktory udaje rozwiazanie.
- [ ] Bledy danych wejsciowych sa obsluzone albo jawnie opisane.

### Weryfikacja

- [ ] Uruchomilem przyklad z README.
- [ ] Sprawdzilem przypadek zwykly i brzegowy.
- [ ] Wiem, co oznacza wynik kontroli.
- [ ] `git status` pokazuje tylko pliki, ktore chce oddac.

### Higiena repozytorium

- [ ] Brak sekretow i danych osobowych.
- [ ] Brak katalogow IDE i plikow tymczasowych.
- [ ] Linki w README prowadza do istniejacych plikow.

## Zadanie dla studenta

Przygotuj katalog `zadania/01-checklista` z:

- plikiem `README.md` wedlug szablonu powyzej,
- jednym plikiem `wynik.txt` zawierajacym przykladowy rezultat,
- sekcja "Sprawdzenie" z trzema przypadkami,
- checklista zaznaczona tylko w punktach, ktore rzeczywiscie wykonales.

Nastepnie wykonaj lokalnie instrukcje z README osoby siedzacej obok. Nie udzielaj jej
ustnych wyjasnien, dopoki nie odnotuje pierwszego miejsca, w ktorym utknela.

### Rozwiazanie i wyjasnienie

Przykladowy katalog:

```text
zadania/01-checklista/
|-- README.md
`-- wynik.txt
```

Przykladowy plik `README.md`:

```markdown
# Sprawdzenie temperatury

## Cel
Pokazac wynik dla wartosci 20 stopni Celsjusza.

## Uruchomienie
Otworz plik `wynik.txt` i porownaj go z sekcja "Sprawdzenie".

## Sprawdzenie
- zwykly: 20 -> 20 stopni Celsjusza
- brzegowy: 0 -> 0 stopni Celsjusza
- niepoprawny: brak wartosci -> przypadek opisany jako "brak danych"

## Zakres oddania
- [x] opis celu
- [x] instrukcja
- [x] trzy przypadki kontroli
```

Rozwiazanie jest minimalne, ale kompletne: odbiorca wie, co ma sprawdzic, a autor nie udaje,
ze test automatyczny istnieje, gdy wykonano tylko kontrole reczna.

## Diagram

```mermaid
flowchart TD
    A[Tresc zadania] --> B[README i struktura]
    B --> C[Implementacja]
    C --> D[Uruchomienie]
    D --> E[Przypadki kontroli]
    E --> F[Checklista]
    F --> G[Link do oddania]
```

Zrodlo diagramu: [checklista oddania](diagramy/checklista-oddania.mmd).
