# 4. Zadanie: utwórz swoje portfolio na GitHub Pages

## Cel zadania

Samodzielnie przygotuj niewielkie portfolio w zwykłym HTML, CSS i JavaScript, a następnie
udostępnij je pod publicznym adresem GitHub Pages. Pracuj etapami: po każdej zmianie zapisz
pliki, przewidź wynik i sprawdź go w przeglądarce.

## Wymagania projektu

Portfolio ma:

- przedstawiać Ciebie za pomocą imienia lub pseudonimu oraz krótkiego opisu,
- zawierać osobne strony startową, „O mnie” i „Projekty”,
- prezentować co najmniej dwa projekty, każdy z opisem i informacją o użytych technologiach,
- mieć wspólną nawigację i stopkę na wszystkich stronach,
- używać zewnętrznego arkusza CSS i dostosowywać się do wąskiego ekranu,
- zawierać co najmniej jedną działającą interakcję JavaScript,
- być opublikowane przez GitHub Pages i sprawdzone pod adresem zdalnym.

Nie publikuj haseł, tokenów, adresu domowego, prywatnego numeru telefonu ani innych
informacji, których nie chcesz udostępnić publicznie. Witryna GitHub Pages może być
dostępna publicznie także wtedy, gdy repozytorium źródłowe jest prywatne.

## Proponowane kroki wykonania

### 1. Przygotuj katalog i pliki

Utwórz katalog `portfolio` i otwórz cały katalog w VS Code albo WebStorm. Utwórz pliki:

```text
portfolio/
├── index.html
├── about.html
├── projects.html
├── styles.css
└── script.js
```

Otwórz `index.html` w przeglądarce. Ustaw edytor i przeglądarkę obok siebie, a następnie
otwórz narzędzia deweloperskie klawiszem **F12**.

### 2. Zbuduj treść w HTML

Zacznij od pełnego dokumentu HTML: `doctype`, `<html lang="pl">`, kodowanie UTF-8,
`viewport`, opisowy `title` i `body`. Przygotuj stronę startową z:

- nagłówkiem i nawigacją do pozostałych stron,
- sekcją powitalną z nagłówkiem `h1` i krótkim opisem,
- sekcją prezentującą poznawane technologie,
- odsyłaczem do strony projektów,
- stopką.

Skopiuj wspólną nawigację i stopkę do `about.html` oraz `projects.html`. Zmień tytuł karty
i treść każdej podstrony. Na stronie projektów dodaj co najmniej dwa elementy `article`.
Dla każdego opisz nazwę, cel, użyte technologie i — jeśli istnieje — dodaj odsyłacz do kodu.

Sprawdź w przeglądarce wszystkie odsyłacze i hierarchię nagłówków. Nie przechodź dalej,
jeśli podstrona nie otwiera się pod dokładnie taką nazwą, jakiej używa link.

### 3. Nadaj stronie wygląd w CSS

W `<head>` każdego dokumentu dołącz wspólny arkusz:

```html
<link rel="stylesheet" href="styles.css">
```

W `styles.css` ustaw model pudełkowy, krój pisma, kolory, odstępy, wygląd kart projektów
i stan fokusu linków oraz przycisków. Gdy podstawowy wygląd działa, zmniejsz szerokość
okna przeglądarki. Dopasuj układ tak, aby treść mieściła się bez poziomego przewijania.

### 4. Dodaj małą interakcję w JavaScript

Wybierz jedną funkcję, np. przycisk „Pokaż ciekawostkę”, który po kliknięciu zmienia treść
na stronie głównej. Dodaj `script.js` przed `</body>` tej strony, znajdź elementy przez
`document.querySelector` i obsłuż `click` metodą `addEventListener`.

Przed kliknięciem przewidź efekt. Potem otwórz **Console** w DevTools, odśwież stronę,
wykonaj interakcję i sprawdź, czy nie pojawiły się błędy. Jeśli skrypt jest dołączony
do podstron bez danego przycisku, zabezpiecz kod przed brakiem elementu.

### 5. Sprawdź lokalną wersję

- Otwórz `index.html` i przejdź do każdej podstrony, a następnie wróć przez nawigację.
- Sprawdź tytuły kart, tekst, odsyłacze, style i działanie interakcji.
- Zmniejsz szerokość okna i sprawdź układ na wąskim ekranie.
- W DevTools obejrzyj **Elements** i **Console**; napraw błędy i brakujące zasoby.
- Uruchom `git status` i upewnij się, że do repozytorium trafią wyłącznie pliki projektu.

### 6. Utwórz repozytorium i wyślij projekt

Utwórz repozytorium na GitHubie, np. `portfolio`. Jeśli używasz już lokalnego repozytorium
Git, sprawdź jego adres `remote`, zanim wyślesz zmiany. W katalogu projektu wykonaj:

```text
git init
git add index.html about.html projects.html styles.css script.js
git commit -m "Dodaj stronę portfolio"
git branch -M main
git remote add origin ADRES_REPOZYTORIUM
git push -u origin main
```

Zastąp `ADRES_REPOZYTORIUM` adresem swojego repozytorium. Przed `git add` sprawdź
`git status`; nie dodawaj danych prywatnych ani sekretów.

### 7. Opublikuj stronę przez GitHub Pages

1. Otwórz repozytorium na GitHubie i przejdź do **Settings → Pages**.
2. W **Build and deployment** wybierz **Deploy from a branch**.
3. Ustaw gałąź `main` oraz katalog `/(root)`, a następnie kliknij **Save**.
4. Poczekaj na publikację i skopiuj adres strony pokazany w ustawieniach.
5. Dla repozytorium projektu adres zwykle ma postać
   `https://NAZWA-UŻYTKOWNIKA.github.io/NAZWA-REPOZYTORIUM/`.

Plik startowy musi znajdować się w katalogu publikacji i nazywać się dokładnie
`index.html`. Przy tej konfiguracji katalogiem publikacji jest główny katalog repozytorium.

### 8. Wykonaj test opublikowanej wersji

Otwórz otrzymany adres w nowej karcie, najlepiej w oknie prywatnym. Sprawdź wszystkie
podstrony, style, odsyłacze i interakcję. W DevTools upewnij się, że konsola nie pokazuje
błędów, a pliki nie zwracają błędu 404. Na koniec sprawdź stronę na wąskim ekranie.

## Checklista oddania

- [ ] Działający publiczny adres GitHub Pages.
- [ ] Link do repozytorium źródłowego na GitHubie.
- [ ] Trzy strony HTML z działającą nawigacją i opisowymi tytułami.
- [ ] Co najmniej dwa opisane projekty.
- [ ] Wspólny arkusz CSS, który działa na szerokim i wąskim ekranie.
- [ ] Działająca interakcja JavaScript bez błędów w konsoli.
- [ ] Krótki opis tego, co samodzielnie wykonałem i sprawdziłem.

## Materiały i referencje

- [Laboratorium 05: Pierwsza strona HTML, CSS i JavaScript](https://pjmpr.github.io/WARP2627/laboratoria/lab-05.html)
- [MDN: Podstawowa składnia HTML](https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Structuring_content/Basic_HTML_syntax)
- [MDN: Pierwsze kroki z CSS](https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Styling_basics/Getting_started)
- [MDN: Czym jest JavaScript?](https://developer.mozilla.org/en-US/docs/Learn_web_development/Core/Scripting/What_is_JavaScript)
- [GitHub Docs: Szybki start GitHub Pages](https://docs.github.com/en/pages/quickstart)
- [GitHub Docs: Konfigurowanie źródła publikacji GitHub Pages](https://docs.github.com/en/pages/getting-started-with-github-pages/configuring-a-publishing-source-for-your-github-pages-site)
