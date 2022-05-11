namespace D01Introduction.FPCSharp;

public static class F04_Tuples
{
    // Se está utilizando el operador rango ".."
    public static (string, string) SplitAt1(this string s, int at)
        => (s[..at], s[at..]);

    public static (string baseCcy, string quoteCcy) SplitAt2(this string s, int at)
        => (s[..at], s[at..]);

    public static (IEnumerable<int> list1, IEnumerable<int> list2) Partition(this IEnumerable<int> list,
        Func<int, bool> funcPartition)
    {
        var l1 = new List<int>();
        var l2 = new List<int>();

        list.ToList()
            .ForEach(n =>
            {
                if (funcPartition(n))
                    l1.Add(n);
                else
                    l2.Add(n);
            });

        return (l1, l2);
    }

    public static void Example()
    {
        Console.WriteLine("\nF04 ==> Ejemplo con Tuplas.");

        var (s1, s2) = "EURUSD".SplitAt1(3);
        var pair = "EURUSD".SplitAt2(3);
        Console.WriteLine($"{s1} - {s2}");
        Console.WriteLine($"{pair.baseCcy} - {pair.quoteCcy}");

        var (list1, list2) = Enumerable.Range(1, 20)
            .Partition(n => n % 2 == 0);
        Console.WriteLine($"Pares: {string.Join(" ", list1)}");
        Console.WriteLine($"Impares: {string.Join(" ", list2)}");
    }
}
