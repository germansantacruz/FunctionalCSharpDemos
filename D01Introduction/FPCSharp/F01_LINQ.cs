using System.Text;
namespace D01Introduction.FPCSharp;

public static class F01_LINQ
{
    private static string ExampleWithLINQ(Func<int, bool> predicate)
    {
        StringBuilder sb = new();
        Enumerable.Range(1, 100)
            .Where(predicate)
            .OrderByDescending(n => n)
            .Select(n => $"{n}%")
            .ToList()
            .ForEach(n => sb.Append($"{n} "));

        return sb.ToString();
    }

    public static void Example()
    {
        Console.WriteLine("\nF01 ==> Ejemplo con LINQ: Filtrar de 1-100 los múltiplos de 20 y ordernar de forma descendente.");
        Console.WriteLine(ExampleWithLINQ(n => n % 20 == 0));
    }
}
