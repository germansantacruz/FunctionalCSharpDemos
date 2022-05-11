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

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Ejemplo con LINQ, Filtrar de 1-100 los múltiplos de\n20 y ordernar de forma descendente:", color);

        Console.WriteLine(ExampleWithLINQ(n => n % 20 == 0));
    }
}
