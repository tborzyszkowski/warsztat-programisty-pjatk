# 2. CSS: wygląd i układ

## Cel

CSS (Cascading Style Sheets) określa wygląd i układ elementów HTML. Po tym temacie student
potrafi dołączyć zewnętrzny arkusz stylów, zmienić podstawowe właściwości i przygotować
czytelny układ, który działa także na wąskim ekranie.

## Pojęcia potrzebne na start

- **Reguła CSS** - selektor oraz blok deklaracji, np. `h1 { color: navy; }`.
- **Selektor** - wskazuje elementy, które mają otrzymać style.
- **Właściwość i wartość** - określają, co zmienić i jaki efekt zastosować.
- **Model pudełkowy** - każdy element tworzy pudełko z treścią, paddingiem, obramowaniem
  i marginesem.
- **Responsywność** - dostosowanie układu do dostępnej szerokości ekranu.

## Dołącz zewnętrzny arkusz

Utwórz `styles.css` w tym samym katalogu co `index.html`. W `head` każdego dokumentu HTML
dodaj:

```html
<link rel="stylesheet" href="styles.css">
```

W arkuszu wpisz testową regułę:

```css
body {
  background: tomato;
}
```

Zapisz oba pliki i odśwież stronę. Gdy tło się zmieni, połączenie działa. Usuń regułę
testową i zastąp ją własnymi stylami.

## Ustal bazowe style

```css
* {
  box-sizing: border-box;
}

body {
  margin: 0;
  min-height: 100vh;
  font-family: Arial, sans-serif;
  line-height: 1.6;
  color: #17231f;
  background: #f3f7f5;
}

header,
footer {
  padding: 1rem 1.5rem;
}

main {
  width: min(100% - 2rem, 60rem);
  margin-inline: auto;
  padding-block: 2rem;
}
```

Zmień pojedynczą wartość i odśwież stronę. Zaobserwuj, jak `margin`, `padding`, `font-family`
i `background` wpływają na różne części strony.

## Ostyluj sekcje i karty

Dodaj klasy do wybranych elementów HTML, np. `class="project-card"`, a potem zastosuj
selektor klasy:

```css
.project-card {
  padding: 1.5rem;
  border: 1px solid #b7c8c0;
  border-radius: 0.75rem;
  background: #fff;
}

a {
  color: #075e46;
}

a:focus-visible,
button:focus-visible {
  outline: 3px solid #075e46;
  outline-offset: 3px;
}
```

Selektor elementu, np. `a`, obejmuje wszystkie odsyłacze. Selektor klasy `.project-card`
wybiera elementy z atrybutem `class="project-card"`. Oglądaj reguły i ich wynik w zakładce
**Elements** narzędzi deweloperskich.

## Sprawdź wąski ekran

Karty projektów można ułożyć w siatkę, która na małym ekranie przechodzi do jednej kolumny:

```css
.project-list {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(min(100%, 16rem), 1fr));
  gap: 1rem;
}
```

Użyj narzędzi deweloperskich, aby zmniejszyć szerokość okna. Sprawdź, czy nie pojawia się
poziome przewijanie, tekst pozostaje czytelny, a odsyłacze i przyciski można łatwo wskazać.

## Zadanie kontrolne

1. Dodaj klasę do jednej sekcji i nadaj jej inne tło niż stronie.
2. Zmień `padding`, `border-radius` i kolor akcentu, po jednej wartości naraz.
3. Sprawdź stronę na szerokim i wąskim widoku.
4. Jeśli reguła się nie stosuje, porównaj nazwę klasy w HTML z selektorem CSS oraz sprawdź,
   czy ścieżka `href` wskazuje właściwy arkusz.

## Materiały i referencje

- [Laboratorium 05: Pierwsza strona HTML, CSS i JavaScript](https://pjmpr.github.io/WARP2627/laboratoria/lab-05.html)
- [MDN: Pierwsze kroki z CSS](https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Styling_basics/Getting_started)
- [MDN: Selektory CSS](https://developer.mozilla.org/en-US/docs/Web/CSS/CSS_selectors)
- [MDN: Podstawowe pojęcia modelu pudełkowego](https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Styling_basics/Box_model)
