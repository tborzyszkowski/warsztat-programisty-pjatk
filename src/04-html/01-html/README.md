# 1. HTML: treść i struktura strony

## Cel

HTML (HyperText Markup Language) opisuje treść i strukturę dokumentu. Po tym temacie
student potrafi przygotować poprawny szkielet strony, dobrać elementy do rodzaju treści
i połączyć dokumenty odsyłaczami.

## Pojęcia potrzebne na start

- **Element** - znacznik otwierający, treść i zwykle znacznik zamykający, np. `<p>Tekst</p>`.
- **Atrybut** - dodatkowa informacja elementu, np. `href` w odsyłaczu.
- **Element semantyczny** - element, którego nazwa opisuje rolę zawartości, np. `nav`, `main`
  albo `footer`.
- **Ścieżka względna** - adres pliku liczony od położenia bieżącego dokumentu, np.
  `projects.html`.

## Zacznij od kompletnego dokumentu

Utwórz `index.html` i wpisz:

```html
<!doctype html>
<html lang="pl">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Portfolio — Imię lub pseudonim</title>
</head>
<body>
  <h1>Moje portfolio</h1>
  <p>Uczę się tworzyć strony internetowe.</p>
</body>
</html>
```

Zapisz plik i otwórz go w przeglądarce. Porównaj tytuł widoczny na karcie z nagłówkiem
widocznym w treści strony. Element `title` opisuje dokument; nie zastępuje nagłówka `h1`.

## Opisz treść elementami semantycznymi

Rozbuduj treść `body` o nagłówek witryny, nawigację, główną zawartość i stopkę. Użyj
nagłówków w kolejności odpowiadającej strukturze informacji:

```html
<header>
  <p>Portfolio</p>
  <nav aria-label="Główna nawigacja">
    <a href="index.html">Start</a>
    <a href="about.html">O mnie</a>
    <a href="projects.html">Projekty</a>
  </nav>
</header>

<main>
  <section aria-labelledby="intro-title">
    <p>Student / początkujący programista</p>
    <h1 id="intro-title">Cześć, jestem [imię lub pseudonim]</h1>
    <p>Uczę się budować czytelne strony internetowe.</p>
    <a href="projects.html">Zobacz moje projekty</a>
  </section>

  <section aria-labelledby="skills-title">
    <h2 id="skills-title">Poznaję</h2>
    <ul>
      <li>HTML</li>
      <li>CSS</li>
      <li>JavaScript</li>
    </ul>
  </section>
</main>

<footer>
  <p>Portfolio wykonane podczas Warsztatu Programisty.</p>
</footer>
```

Treści w nawiasach kwadratowych zastąp informacjami, które możesz bezpiecznie opublikować.
Nie dodawaj danych osobowych, których nie chcesz udostępniać publicznie.

## Zbuduj podstrony i sprawdź odsyłacze

Utwórz `about.html` i `projects.html`. Każdy dokument powinien mieć własny opisowy `title`,
ten sam `header` z nawigacją, dokładnie jeden główny nagłówek `h1`, element `main` z treścią
odpowiednią dla strony oraz wspólną stopkę. Strona projektów może zawierać listę kart:

```html
<section aria-labelledby="projects-title">
  <h1 id="projects-title">Projekty</h1>
  <article>
    <h2>Moja pierwsza strona</h2>
    <p>Krótki opis projektu i wykorzystanych technologii.</p>
    <a href="ADRES_REPOZYTORIUM">Kod źródłowy</a>
  </article>
</section>
```

Otwórz `index.html` i przejdź każdym odsyłaczem. Wróć do strony startowej przez nawigację.
Sprawdź, czy nazwy plików w odsyłaczach są identyczne z nazwami plików na dysku — wielkość
liter ma znaczenie po publikacji.

## Zadanie kontrolne

1. Wskaż elementy `head` i `body` oraz wyjaśnij różnicę między `title` a `h1`.
2. Dodaj na stronie o sobie sekcję zainteresowań z listą co najmniej trzech pozycji.
3. Tymczasowo usuń zamknięcie jednego znacznika listy; obejrzyj drzewo w DevTools, a następnie
   napraw dokument.
4. Zapisz, które elementy pełnią rolę nawigacji, głównej treści i stopki.

## Materiały i referencje

- [Laboratorium 05: Pierwsza strona HTML, CSS i JavaScript](https://pjmpr.github.io/WARP2627/laboratoria/lab-05.html)
- [MDN: Podstawowa składnia HTML](https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Structuring_content/Basic_HTML_syntax)
- [MDN: Elementy HTML](https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements)
- [W3C: Walidator HTML](https://validator.w3.org/)
