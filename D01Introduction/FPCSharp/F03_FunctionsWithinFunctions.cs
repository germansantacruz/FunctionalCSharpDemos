namespace D01Introduction.FPCSharp;

public static class F03_FunctionsWithinFunctions
{
    // Al escribir muchas funciones simples, muchas se llamarán de una sola ubicación;
    // C# permite hacer esto explícito al declarar funciones dentro del ámbito de otra función.

    private static string MapToString(this int[] list, Func<int[], string> funcMapping)
        => funcMapping(list);

    private enum Operation
    {
        add20, filterMultiple7, filterOdd
    }

    private static string GetNumbers(Operation op)
    {
        var data = Enumerable.Range(1, 20);
        IEnumerable<int> result;

        Func<int, int> add20 = number => number + 20;
        var filterMultiple7 = (int number) => (number % 7) == 0;
        // Función local
        // Se puede declarar como estática para mejorar el rendimiento y no accede 
        // a variables del mismo ámbito adjunto.
        static bool FilterOdd(int number) => (number % 2) != 0;

        switch (op)
        {
            case Operation.add20:
                result = data.Select(add20);
                break;
            case Operation.filterMultiple7:
                result = data.Where(filterMultiple7);
                break;
            case Operation.filterOdd:
                result = data.Where(FilterOdd);
                break;
            default:
                return "";
        }

        return result.ToArray()
            .MapToString(list => string.Join(" ", list));
    }

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Ejemplo Funciones dentro de Funciones:", color);
        Console.WriteLine("Input: 1 - 20");
        Console.Write("Elija una opción, 1) Sumar veinte 2) Filtrar múltiplos de siete 3) Filtrar impares: ");
        var op = Console.ReadLine() ?? "10";

        Console.WriteLine(GetNumbers((Operation)(int.Parse(op) - 1)));
    }
}
