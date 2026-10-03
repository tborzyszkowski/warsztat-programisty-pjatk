public static class Algorytmy
{
    public static double PoleProstokata(double szerokosc, double wysokosc)
    {
        if (!double.IsFinite(szerokosc) || !double.IsFinite(wysokosc))
        {
            throw new ArgumentException("Boki muszą być skończonymi liczbami.");
        }

        if (szerokosc < 0 || wysokosc < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(szerokosc), "Boki nie mogą być ujemne.");
        }

        return szerokosc * wysokosc;
    }

    public static double Srednia(IReadOnlyList<double> values)
    {
        ArgumentNullException.ThrowIfNull(values);
        if (values.Count == 0)
        {
            throw new ArgumentException("Lista nie może być pusta.", nameof(values));
        }

        double sum = 0;
        foreach (double value in values)
        {
            if (!double.IsFinite(value))
            {
                throw new ArgumentException("Lista musi zawierać skończone liczby.", nameof(values));
            }

            sum += value;
        }

        return sum / values.Count;
    }

    public static long Silnia(int number)
    {
        if (number < 0 || number > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Silnia obsługuje liczby od 0 do 20.");
        }

        long result = 1;
        for (int current = 2; current <= number; current++)
        {
            result *= current;
        }

        return result;
    }

    public static long Nwd(int firstNumber, int secondNumber)
    {
        long first = Math.Abs((long)firstNumber);
        long second = Math.Abs((long)secondNumber);
        if (first == 0 && second == 0)
        {
            throw new ArgumentException("NWD dla dwóch zer nie jest określone.");
        }

        while (second != 0)
        {
            long remainder = first % second;
            first = second;
            second = remainder;
        }

        return first;
    }

    public static bool CzyPierwsza(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int divisor = 2; divisor <= number / divisor; divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }
}
