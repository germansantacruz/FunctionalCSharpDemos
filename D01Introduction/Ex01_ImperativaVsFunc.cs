namespace D01Introduction;

public static class Ex01_ImperativaVsFunc
{
    // ***********************************************************************
    // Comparando estilo funcional vs Imperativa
    // ***********************************************************************

    private class Person
    {
        public string Name { get; init; } = "";
        public string Country { get; init; } = "";
        public bool IsMarried { get; init; }
    }

    private static IEnumerable<Person> GetData()
    {
        var people = new List<Person>()
        {
            new Person() { Name = "David", Country = "Bolivia", IsMarried = true },
            new Person() { Name = "Maria", Country = "Bolivia", IsMarried = false },
            new Person() { Name = "Noelia", Country = "Bolivia", IsMarried = true },
            new Person() { Name = "Carmen", Country = "Bolivia", IsMarried = true },
            new Person() { Name = "Viviana", Country = "Bolivia", IsMarried = false },
            new Person() { Name = "Laura", Country = "Bolivia", IsMarried = true },
            new Person() { Name = "Carlos", Country = "Bolivia", IsMarried = false },
            new Person() { Name = "Shakira", Country = "Bolivia", IsMarried = true },
            new Person() { Name = "Avril", Country = "Bolivia", IsMarried = true },
            new Person() { Name = "Daniela", Country = "Bolivia", IsMarried = true }
        };
        return people;
    }

    // Buscar las personas casadas, forma imperativa ¿Cómo?
    // Usando instrucciones de control de flujo
    private static string GetMarriedPeople()
    {
        var data = GetData();
        var result = new List<string>();

        foreach (var item in data)
        {
            if (item.IsMarried)
                result.Add(item.Name.ToUpper());
        }

        var concatNames = string.Join(", ", result);
        return concatNames;
    }

    // Forma funcional ¿Qué quiero?
    private static string GetMarriedPeople2()
    {
        return GetData()
            .MyCustomWhere(i => i.IsMarried)
            .Select(i => i.Name.ToUpper())
            .ToStringPeopleList();
    }

    private static string ToStringPeopleList(this IEnumerable<string> lista)
    {
        return string.Join(", ", lista);
    }

    private static IEnumerable<Person> MyCustomWhere(this IEnumerable<Person> lista,
        Func<Person, bool> predicate)
    {
        var result = new List<Person>();

        foreach (var item in lista)
        {
            if (predicate(item))
                result.Add(item);
        }

        return result;
    }

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Programación imperativa vs funcional:", color);

        Console.WriteLine(GetMarriedPeople());
        Console.WriteLine(GetMarriedPeople2());
    }
}