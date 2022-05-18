namespace D01Introduction;

public static class Ex02_Immutability
{
    // *******************************************************************************
    // Evitar mutación de estado: 
    // Para filtrar y ordenar una lista, no se modifica la original se crea una nueva.
    // *******************************************************************************

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
        Util.ShowTitle("Evitar mutación de estado:", color);

        var data = GetData();
        Console.WriteLine($"Lista Original:          {data.ToStringCustom()}");
        Console.WriteLine($"Lista Original filtrada: {FilterData(data).ToStringCustom()}");
        Console.WriteLine($"Lista Original:          {data.ToStringCustom()}");
    }
}
