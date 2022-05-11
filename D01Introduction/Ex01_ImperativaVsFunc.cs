namespace D01Introduction;

public static class Ex01_ImperativaVsFunc
{
    public static IEnumerable<Person> GetData()
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
    public static string GetMarriedPeople()
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
    public static string GetMarriedPeople2()
    {
        return GetData()
            .MyCustomWhere(i => i.IsMarried)
            .Select(i => i.Name.ToUpper())
            .ToStringPeopleList();
    }

    public static string ToStringPeopleList(this IEnumerable<string> lista)
    {
        return string.Join(", ", lista);
    }

    public static IEnumerable<Person> MyCustomWhere(this IEnumerable<Person> lista,
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
}
public class Person
{
    public string Name { get; set; }
    public string Country { get; set; }
    public bool IsMarried { get; set; }
}
