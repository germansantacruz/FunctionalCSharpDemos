namespace D01Introduction.FPCSharp;

public static class F06_PatternMatching
{
    private class Address
    {
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public int PostalCode { get; set; }
    }
    private class Person
    {
        public string Name { get; set; } = "";
        public Address? Address { get; set; }
    }

    private static void Example1()
    {
        int number = 10;
        string data = "100";
        Person person = new()
        {
            Name = "David",
            Address = new Address() { City = "Santa Cruz", Country = "Bolivia", PostalCode = 50 }
        };

        // Type Pattern
        // ****************************

        object? obj = null;
        if (obj is null)
            Console.WriteLine("La variable obj es nula.");

        obj = number;
        if (obj is not null)
            Console.WriteLine("La variable obj no es nula.");

        if (obj is int)
            Console.WriteLine($"La variable obj es de tipo entero.");

        obj = data;
        if (obj is not int)
            Console.WriteLine($"La variable obj no es de tipo entero.");

        obj = person;
        if (obj is Person)
            Console.WriteLine($"La variable obj es de tipo Person.");

        // Property Pattern
        // ****************************

        if (obj is Person { Name: "German" })
            Console.WriteLine($"La variable obj es de tipo Person y con Name: German.");

        if (obj is Person { Name: "David" })
            Console.WriteLine($"La variable obj es de tipo Person y con Name: David.");

        if (obj is Person { Name: "David" } per1)
            Console.WriteLine($"La variable obj es de tipo Person y con Name: David, Ciudad: {per1?.Address?.City}");

        obj = data;
        if (obj is string { Length: 3 })
            Console.WriteLine($"La variable obj es de tipo string y con Length: 3.");

        // Constant y relational Pattern (<, >, <=, >=)
        // Pattern combinators and, or, not
        // ****************************
        obj = null;
        if (obj is 10)
            Console.WriteLine($"La variable obj es de tipo int y con valor: 10.");

        //if ((int)obj == 10)
        //    Console.WriteLine($"La variable obj es de tipo int y con valor: 10.");
        obj = number;
        if (obj is >= 1 and <= 10)
            Console.WriteLine($"La variable obj es de tipo int y tiene un valor entre 1 y 10.");

        obj = person;
        if (obj is Person { Address.PostalCode: > 40 and < 100, Name: "David" })
        {
            Console.WriteLine($"La variable obj es de tipo Person y su Address.PostalCode tiene un valor entre 41 y 99.");
        }
    }

    private static bool IsLetter(this char c) =>
        c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');

    private abstract class Shape { public int Area { get; set; } }
    private class Circle : Shape { public int Radius { get; set; } }
    private class Square : Shape { public int Width { get; set; } }

    // Switch expression
    private static void Example2()
    {
        Person person = new()
        {
            Name = "David",
            Address = new Address() { City = "Santa Cruz", Country = "Bolivia", PostalCode = 50 }
        };

        Shape shape1 = new Circle { Area = 100, Radius = 5 };
        Shape shape2 = new Square { Area = 100, Width = 10 };

        string details1 = person.Address.PostalCode switch
        {
            10 or 11 => "10-11",
            >= 0 and <= 9 => "0-9",
            >= 12 and <= 40 => "12-40",
            >= 41 => "51-",
            _ => "default case"
        };
        Console.WriteLine(details1);

        Shape shape = shape1;
        string details2 = shape switch
        {
            Circle cir => $"This is a circle with radius: {cir.Radius}.",
            Square { Width: 15, Area: 150 } => $"Square with width: 15 and Area: 150.",
            { Area: 101 } sh => $"The area is {sh.Area}.",
            { Area: var area } => $"Area: {area}",
            _ => "Default"
        };
        Console.WriteLine(details2);

        shape = shape2;
        string details3 = shape switch
        {
            Circle { Radius: > 25 and < 100 } => $"This is a circle with radius between 26 and 99.",
            Square { Width: 10 } sq => $"This is a square with Width: 10.",
            var sh => $"Area: {sh.Area}."
        };
        Console.WriteLine(details3);
    }

    private static decimal RateByCountry(string country)
        => country switch
        {
            "bo" => 0.16m,
            "ar" => 0.10m,
            "br" => 0.15m,
            _ => throw new ArgumentException($"No existe el Impuesto para {country}.")
        };

    private static decimal GetDiscount(int groupSize, DateTime visitDate)
        => (groupSize, visitDate.DayOfWeek) switch
        {
            ( <= 0, _) => throw new ArgumentException("Group size must be positive."),
            (_, DayOfWeek.Saturday or DayOfWeek.Sunday) => 0.0m,
            ( >= 5 and < 10, DayOfWeek.Monday) => 20.0m,
            (_, DayOfWeek.Thursday) => 50.0m,
            _ => 0.0m
        };

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Ejemplos de Pattern Matching:", color);

        Example1();
        Console.WriteLine($"El caracter es una letra? {IsLetter('5')}");
        Example2();
        Console.WriteLine($"El impuesto para Bolivia es: {RateByCountry("bo")}");
        Console.WriteLine($"Su descuento del día es: {GetDiscount(1, DateTime.Now)}");
    }
}