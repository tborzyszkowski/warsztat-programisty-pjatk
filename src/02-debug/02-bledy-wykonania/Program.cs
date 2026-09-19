using System;
using System.Diagnostics;

Console.WriteLine("Scenariusz błędów wykonania");

string[] scores = ["4", "5", "3"];
try
{
    double average = CalculateAverage(scores);
    Console.WriteLine($"Średnia ocen: {average:0.00}");
}
catch (FormatException exception)
{
    LogError("Nie udało się odczytać oceny", exception);
}

string report = BuildReport("debugger", 3);
Debug.Assert(report.Length > 0, "Raport nie może być pusty");
Console.WriteLine(report);

static double CalculateAverage(string[] values)
{
    if (values.Length == 0)
    {
        throw new ArgumentException("Lista ocen nie może być pusta", nameof(values));
    }

    int total = 0;
    foreach (string value in values)
    {
        total += int.Parse(value);
    }

    return (double)total / values.Length;
}

static string BuildReport(string topic, int issueCount)
{
    if (string.IsNullOrWhiteSpace(topic))
    {
        throw new ArgumentException("Temat nie może być pusty", nameof(topic));
    }

    return $"Temat: {topic}; znalezionych problemów: {issueCount}";
}

static void LogError(string message, Exception exception)
{
    Console.Error.WriteLine($"[ERROR] {DateTime.UtcNow:O} {message}");
    Console.Error.WriteLine(exception.ToString());
}
