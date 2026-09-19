using System;

Console.WriteLine("Scenariusz debuggera: podsumowanie wyników");
RunScenario();

static void RunScenario()
{
    int[] values = [4, 7, 2, 9];
    int total = CalculateTotal(values);
    int maximum = FindMaximum(values);
    double average = CalculateAverage(total, values.Length);

    Console.WriteLine($"Suma: {total}");
    Console.WriteLine($"Maksimum: {maximum}");
    Console.WriteLine($"Średnia: {average:0.00}");
}

static int CalculateTotal(int[] values)
{
    int total = 0;
    foreach (int value in values)
    {
        total += value;
    }

    return total;
}

static int FindMaximum(int[] values)
{
    int maximum = values[0];
    foreach (int value in values)
    {
        if (value > maximum)
        {
            maximum = value;
        }
    }

    return maximum;
}

static double CalculateAverage(int total, int count)
{
    return (double)total / count;
}
