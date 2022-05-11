namespace D01Introduction;

public static class Ex02_Immutability
{
    private static int[] GetData()
    {
        return Enumerable.Range(1, 10).ToArray();
    }

    private static int[] FilterData(int[] data)
    {
        var isOdd = (int number) => number % 2 == 1;

        // Ordernar y filtrar los datos sólo impares
        return data.Where(isOdd)
            .OrderBy(n => n)
            .ToArray();
    }

    private static string ToStringCustom(this int[] lista)
    {
        return string.Join(", ", lista);
    }

    public static void RunExample(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine("\nEvitar mutación de estado:");
        Console.WriteLine("-----------------------------------------------------\n");
        Console.ForegroundColor = ConsoleColor.White;

        var data = GetData();
        Console.WriteLine($"Lista Original:          {data.ToStringCustom()}");
        Console.WriteLine($"Lista Original filtrada: {FilterData(data).ToStringCustom()}");
        Console.WriteLine($"Lista Original:          {data.ToStringCustom()}");
    }
}
