# 3. JavaScript: interakcja ze stroną

## Cel

JavaScript dodaje stronie zachowanie, np. reakcję na kliknięcie. Po tym temacie student
potrafi dołączyć skrypt, znaleźć element HTML przez DOM, obsłużyć zdarzenie i wykorzystać
konsolę przeglądarki przy diagnozowaniu problemu.

## Pojęcia potrzebne na start

- **DOM** - obiektowa reprezentacja dokumentu HTML, z którą może pracować JavaScript.
- **Selektor** - tekst wskazujący element, np. `#bio` dla identyfikatora `bio`.
- **Zdarzenie** - czynność lub sytuacja, na którą może zareagować skrypt, np. `click`.
- **Listener** - funkcja uruchamiana po wystąpieniu wskazanego zdarzenia.

## Dołącz skrypt i sprawdź konsolę

Utwórz `script.js`. W dokumencie zawierającym interakcję umieść odwołanie tuż przed
zamykającym `body`:

```html
<script src="script.js"></script>
</body>
```

W `script.js` wpisz:

```javascript
console.log("Skrypt działa");
```

Zapisz pliki, odśwież stronę i odczytaj komunikat w zakładce **Console**. Konsola służy
do diagnostyki; ten komunikat nie jest treścią widoczną dla odwiedzających stronę.

## Obsłuż kliknięcie

Dodaj w HTML elementy z unikalnymi identyfikatorami:

```html
<p id="bio">Uczę się tworzyć strony internetowe.</p>
<button id="fact-button" type="button">Pokaż ciekawostkę</button>
```

Zastąp testowy kod w `script.js`:

```javascript
const factButton = document.querySelector("#fact-button");
const bio = document.querySelector("#bio");

if (factButton && bio) {
  factButton.addEventListener("click", function () {
    bio.textContent = "Ta treść została zmieniona przez JavaScript.";
    factButton.textContent = "Gotowe!";
  });
}
```

Najpierw przewidź, co się zmieni po kliknięciu. Następnie odśwież stronę i sprawdź rezultat.
Warunek pozwala bezpiecznie dołączyć ten sam skrypt również do strony, na której nie ma
przycisku ani elementu `bio`.

## Znajdź i napraw błąd

1. Zmień tymczasowo selektor `#fact-button` na `#fact-buton`.
2. Odśwież stronę, otwórz **Console** i kliknij przycisk.
3. Odczytaj pierwszy czerwony komunikat, plik i numer wiersza.
4. W konsoli sprawdź wynik `document.querySelector("#fact-buton")`.
5. Przywróć poprawny identyfikator i upewnij się, że kliknięcie znów działa.

Po poprawce sprawdź także zwykły widok strony. Błąd JavaScript nie powinien uniemożliwiać
odczytania treści i używania odsyłaczy.

## Zadanie kontrolne

1. Dodaj przycisk, który po kliknięciu zmieni treść jednego elementu.
2. Wytłumacz, kiedy uruchamia się funkcja przekazana do `addEventListener`.
3. Sprawdź, co zwróci `querySelector`, gdy w dokumencie nie ma elementu pasującego do selektora.
4. Otwórz konsolę i upewnij się, że po naprawieniu kodu nie pozostały błędy.

## Materiały i referencje

- [Laboratorium 05: Pierwsza strona HTML, CSS i JavaScript](https://pjmpr.github.io/WARP2627/laboratoria/lab-05.html)
- [MDN: Czym jest JavaScript?](https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Scripting/What_is_JavaScript)
- [MDN: Wprowadzenie do DOM](https://developer.mozilla.org/en-US/docs/Web/API/Document_Object_Model/Introduction)
- [MDN: addEventListener](https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener)
