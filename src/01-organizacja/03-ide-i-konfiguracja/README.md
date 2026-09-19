# 03. IDE, uruchamianie kodu i konfiguracja

## Cel

Student potrafi wybrac narzedzie adekwatne do zadania, otworzyc projekt, uruchomic prosty
program oraz odroznic formatowanie od lintingu. Nie chodzi o zapamietanie jednego IDE.
Chodzi o umiejetnosc znalezienia polecenia, ustawienia i komunikatu bledu.

## Porownanie IDE i edytora

| Narzedzie | Najmocniejszy obszar | Kiedy wybrac | Na co uwazac |
| --- | --- | --- | --- |
| Visual Studio | duze aplikacje .NET i C++ na Windows | gdy projekt wymaga pelnego srodowiska Microsoft | instalacja jest wieksza, a funkcje zalezne od workloadu |
| Visual Studio Code | lekka praca z wieloma jezykami i plikami | gdy potrzebujesz elastycznego edytora i terminala | jakosc zalezy od dobranych rozszerzen |
| IntelliJ IDEA | Java, Kotlin i bogate rozumienie projektu | gdy IDE ma analizowac duzy projekt JVM | funkcje webowe zaleza od edycji i pluginow |
| Rider | .NET oraz praca cross-platform | gdy projekt korzysta z C# i ekosystemu .NET | czesc funkcji wymaga licencji lub konta JetBrains |

IDE oznacza zintegrowane srodowisko programistyczne. VS Code jest przede wszystkim
rozszerzalnym edytorem, ale w praktyce moze pelnic role lekkiego IDE.

## Instalacja i pierwszy start

Korzystaj z instalatorow z oficjalnych stron. Podczas laboratorium prowadzacy moze
przygotowac stanowiska wczesniej, ale student powinien umiec powtorzyc te kroki.

### Visual Studio

1. Otworz [strone pobierania Visual Studio](https://visualstudio.microsoft.com/downloads/).
2. Uruchom Visual Studio Installer.
3. Wybierz workload **Node.js development**, jesli uruchamiasz przyklad JavaScript,
   albo workload zgodny z projektem kursowym.
4. Otworz folder projektu przez **Open a local folder**.
5. Otworz terminal w IDE i wykonaj `node przyklad.js`.

### Visual Studio Code

1. Zainstaluj [Visual Studio Code](https://code.visualstudio.com/download).
2. Otworz folder przez **File -> Open Folder**.
3. Zainstaluj rozszerzenia: **EditorConfig for VS Code**, **Prettier - Code formatter**
   oraz **ESLint**.
4. Otworz plik `przyklad.js` z tego katalogu.
5. Otworz zintegrowany terminal i wykonaj `node przyklad.js`.

### IntelliJ IDEA

1. Zainstaluj [IntelliJ IDEA](https://www.jetbrains.com/idea/download/).
2. Otworz folder jako projekt.
3. Sprawdz w ustawieniach, czy obsluga JavaScript i Node.js jest dostepna w wybranej
   edycji; w razie potrzeby wlacz odpowiedni plugin.
4. Wybierz zainstalowany Node.js w ustawieniach projektu.
5. Kliknij prawym przyciskiem `przyklad.js` i wybierz uruchomienie pliku albo wykonaj
   `node przyklad.js` w terminalu IDE.

### Rider

1. Zainstaluj [JetBrains Rider](https://www.jetbrains.com/rider/download/).
2. Otworz folder projektu.
3. Sprawdz pluginy JavaScript/TypeScript i ustawienie interpretera Node.js.
4. Uruchom `przyklad.js` z menu kontekstowego lub przez terminal poleceniem
   `node przyklad.js`.

Jesli przy `node` pojawia sie komunikat, ze polecenie nie istnieje, problem dotyczy
instalacji lub PATH, a nie kodu. Node.js mozna pobrac z [oficjalnej strony](https://nodejs.org/en/download).

## Minimalny przyklad

Kod znajduje sie w pliku [przyklad.js](przyklad.js):

```javascript
const firstNumber = 7;
const secondNumber = 5;
const sum = firstNumber + secondNumber;

console.log(`${firstNumber} + ${secondNumber} = ${sum}`);
```

Oczekiwany wynik:

```text
7 + 5 = 12
```

Ten program pokazuje wartosc zmiennej, operacje matematyczna i wynik w terminalu. Do
pierwszego uruchomienia nie jest potrzebny framework ani dodatkowa biblioteka.

## Formatowanie a linting

- **Formatowanie** zmienia wyglad kodu: wciecia, cudzyslowy, dlugosc wiersza.
- **Linting** analizuje kod i sygnalizuje problemy, np. uzycie niezdefiniowanej zmiennej
  albo pozostawiona zmienna, ktora nigdy nie jest uzywana.
- **Test** sprawdza zachowanie programu dla wybranego wejscia. Sam formatter ani linter
  nie dowodzi, ze obliczenie jest poprawne.

Przykladowy plik `.editorconfig`:

```ini
root = true

[*]
charset = utf-8
end_of_line = lf
insert_final_newline = true
indent_style = space
indent_size = 2
```

Przykladowe skrypty projektu w `package.json`:

```json
{
  "scripts": {
    "format": "prettier --write .",
    "format:check": "prettier --check .",
    "lint": "eslint ."
  }
}
```

Po zainstalowaniu narzedzi w projekcie polecenia wygladaja tak:

```text
npm install --save-dev prettier eslint
npx prettier --check przyklad.js
npx prettier --write przyklad.js
npx eslint przyklad.js
```

Nie trzeba uruchamiac wszystkich polecen jednoczesnie. Najpierw sprawdz kod, potem
sformatuj go, a na koncu ponownie uruchom linter i program.

## Zadanie dla studenta

1. Wybierz jedno z czterech narzedzi i otworz ten katalog jako projekt.
2. Uruchom [przyklad.js](przyklad.js) i zapisz wynik.
3. Zmien wartosc `firstNumber` na `9`.
4. Dodaj w kodzie celowy blad: odwolaj sie do `thirdNumber`, ktora nie istnieje.
5. Uruchom linter lub przeczytaj komunikat IDE.
6. Napraw blad, sformatuj plik i uruchom program ponownie.
7. W swoim README zapisz: wybrane IDE, nazwe rozszerzenia, polecenie uruchomienia,
   komunikat bledu i oczekiwany wynik po naprawie.

### Rozwiazanie i wyjasnienie

Po naprawie plik powinien nadal korzystac tylko ze zdefiniowanych zmiennych:

```javascript
const firstNumber = 9;
const secondNumber = 5;
const sum = firstNumber + secondNumber;

console.log(`${firstNumber} + ${secondNumber} = ${sum}`);
```

Wynik to `9 + 5 = 14`. Linter powinien zglosic odwolanie do `thirdNumber`, bo nie ma
jej definicji w zakresie programu. Samo sformatowanie pliku nie naprawia tego bledu:
formatowanie zmienia zapis, a linting pomaga znalezc podejrzany zapis.

## Diagram

```mermaid
flowchart TD
    A[Otworz projekt] --> B[Wybierz interpreter]
    B --> C[Uruchom przyklad]
    C --> D{Wynik poprawny?}
    D -- nie --> E[Sprawdz komunikat i konfiguracje]
    E --> C
    D -- tak --> F[Formatter]
    F --> G[Linter]
    G --> H[Zapisz konfiguracje i wynik]
```

Zrodlo diagramu: [uruchomienie i konfiguracja IDE](diagramy/uruchomienie-ide.mmd).
