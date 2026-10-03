AssertEqual(12d, Algorytmy.PoleProstokata(4, 3), "pole prostokąta");
AssertEqual(0d, Algorytmy.PoleProstokata(0, 4), "zerowe pole prostokąta");
AssertThrows<ArgumentOutOfRangeException>(() => Algorytmy.PoleProstokata(-1, 4), "ujemny bok");

AssertEqual(4d, Algorytmy.Srednia([2, 4, 6]), "średnia");
AssertEqual(8d, Algorytmy.Srednia([8]), "średnia z jednego elementu");
AssertThrows<ArgumentException>(() => Algorytmy.Srednia([]), "pusta lista");

AssertEqual(120L, Algorytmy.Silnia(5), "silnia");
AssertEqual(1L, Algorytmy.Silnia(0), "silnia zera");
AssertThrows<ArgumentOutOfRangeException>(() => Algorytmy.Silnia(-1), "ujemna silnia");

AssertEqual(6L, Algorytmy.Nwd(18, 24), "NWD");
AssertEqual(9L, Algorytmy.Nwd(0, 9), "NWD z zerem");
AssertThrows<ArgumentException>(() => Algorytmy.Nwd(0, 0), "NWD dwóch zer");

AssertEqual(true, Algorytmy.CzyPierwsza(17), "liczba pierwsza");
AssertEqual(true, Algorytmy.CzyPierwsza(2), "najmniejsza liczba pierwsza");
AssertEqual(false, Algorytmy.CzyPierwsza(1), "jeden nie jest liczbą pierwszą");
AssertEqual(false, Algorytmy.CzyPierwsza(21), "liczba złożona");

Console.WriteLine("Wszystkie przykładowe testy zakończyły się powodzeniem.");

static void AssertEqual<T>(T expected, T actual, string caseName)
{
    if (!EqualityComparer<T>.Default.Equals(expected, actual))
    {
        throw new InvalidOperationException(
            $"Kontrola „{caseName}” nie powiodła się. Oczekiwano: {expected}; otrzymano: {actual}.");
    }
}

static void AssertThrows<TException>(Action action, string caseName)
    where TException : Exception
{
    try
    {
        action();
    }
    catch (TException)
    {
        return;
    }

    throw new InvalidOperationException($"Kontrola „{caseName}” powinna zgłosić {typeof(TException).Name}.");
}
