namespace D01Introduction;

public static class Ex02_Immutability
{
    public static int[] GetData()
    {
        return Enumerable.Range(1, 10).ToArray();
    }

    public static int[] EvitarMutacionDeEstado(int[] data)
    {
        var isOdd = (int number) => number % 2 == 1;

        // Ordernar y filtrar los datos sólo impares
        return data.Where(isOdd)
            .OrderBy(n => n)
            .ToArray();
    }

    public static string ToStringCustom(this int[] lista)
    {
        return string.Join(", ", lista);
    }
}
