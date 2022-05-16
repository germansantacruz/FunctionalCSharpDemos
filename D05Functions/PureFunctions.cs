using System.Text;
using static System.Linq.ParallelEnumerable;
namespace D05Functions;

public static class PureFunctions
{
    // Funciones no puras
    // ***************************************

    private static int Days(DateTime from) => (DateTime.Now - from).Days;

    private static string cadena = "Hola";
    private static string Concat(string msg) => cadena += msg;

    // StringBuilder se pasa por referencia
    private static void Concat(StringBuilder sb, string msg)
        => sb.Append(msg);

    static int counter = 0;
    private static void GetListAsParallel()
    {
        var data = Enumerable.Range(-10000, 20001)
            .Reverse()
            .AsParallel()
            .Select(n => $"{++counter}> {n}")
            .ToArray();

        // Show top 20 numbers
        Console.WriteLine(string.Join("  ", data.Take(20)));
    }

    // Funciones puras
    // ***************************************

    private static int Days(DateTime from, DateTime now) => (now - from).Days;

    private static string Concat(string msg1, string msg2) => msg1 + msg2;

    private static IEnumerable<T> Where2<T>(this IEnumerable<T> lista,
        Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (var item in lista)
        {
            if (predicate(item))
                result.Add(item);
        }

        return result;
    }

    public static void GetListAsParallel2()
    {
        var result = Enumerable.Range(-10000, 20001)
            .Reverse()
            .AsParallel()
            .Zip(Enumerable.Range(1, 20001));

        // Show top 20 numbers
        Console.WriteLine(string.Join("  ", result.Take(20)));
    }

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Ejemplos de Funciones puras/impuras:", color);

        GetListAsParallel();
        GetListAsParallel2();
    }
}
