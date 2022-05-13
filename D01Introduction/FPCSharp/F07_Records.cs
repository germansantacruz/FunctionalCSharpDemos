using System.Text;

namespace D01Introduction.FPCSharp;

public static class F07_Records
{
    //                              **Type**            **Positional properties**
    // record | record class        Por referencia      Inmutables
    // record struct                Por valor           Mutables
    // readonly record struct       Por valor           Inmutables

    private record Person(string Name, DateOnly DateOfBirth);
    private record Client(int CreditLimit, string Group, string Name, DateOnly DateOfBirth)
        : Person(Name, DateOfBirth);

    // Puede ser mutables reemplazando set por init
    private record Person2
    {
        public string Name { get; init; } = default!;
        public DateOnly DateOfBirth { get; init; }
    }

    private record struct PersonAsStruct(string Name, DateOnly DateOfBirth);
    private readonly record struct PersonAsReadOnlyStruct(string Name, DateOnly DateOfBirth);
    private record Person3(string Name, DateOnly DateOfBirth)
    {
        protected virtual bool PrintMembers(StringBuilder builder)
        {
            builder.Append("Print Custom: ");
            builder.Append($"({Name}, {DateOfBirth})");
            return true;
        }
    }

    private static void ExampleRecord()
    {
        // Constructor con parámetros
        var david = new Person("David", new DateOnly(2000, 01, 01));

        // Clonar registro
        var david2 = david with { };
        var client = new Client(1000, "Mayorista", david.Name, david.DateOfBirth);
        // david2.Name = "";       Inmutable
        // client.Name = "";       Inmutable

        // Print con datos
        Console.WriteLine(david);
        Console.WriteLine(client);
        // Igualdad estructural
        Console.WriteLine($"Record David == Record David2? {david == david2}");
        // Igualdad referencial
        Console.WriteLine($"Record David ==Ref Record David2? {ReferenceEquals(david, david2)}");

        // Clonar
        var davidOlder = david with { DateOfBirth = new DateOnly(1999, 01, 01) };
        Console.WriteLine(davidOlder);

        // Desconstrucción del registro
        var (name, dateOfBirth) = david;
        Console.WriteLine($"Name: {name}, DateOfBirth: {dateOfBirth}");

        // Custom Print
        var marga = new Person3("Marga", new DateOnly(2005, 07, 05));
        //var marga2 = marga with { };
        var marga2 = new Person3("Marga", new DateOnly(2005, 07, 05));

        Console.WriteLine(marga);
        Console.WriteLine(marga2);
        Console.WriteLine($"Marga == Marga2? {marga == marga2}");
        Console.WriteLine();
    }

    private static void ExampleRecordStruct()
    {
        // Mutable            record struct
        // Constructor con y sin parámetros
        var personAsStruct = new PersonAsStruct("", DateOnly.MinValue);
        personAsStruct.Name = "Alex";
        personAsStruct.DateOfBirth = new DateOnly(1980, 05, 16);
        Console.WriteLine($"Mutable (record struct): {personAsStruct}");

        var personAsStruct2 = personAsStruct with { };
        personAsStruct2.Name = "AlexClone";
        Console.WriteLine($"Mutable clone (record struct): {personAsStruct2}");

        // Inmutable          readonly record struct
        var personAsReadOnlyStruct = new PersonAsReadOnlyStruct();
        //personAsReadOnlyStruct.Name = "";         // Inmutable
        var personAsReadOnlyStruct2 = new PersonAsReadOnlyStruct("Carmen", new DateOnly(2000, 01, 01));
        //personAsReadOnlyStruct2.Name = "Carla";
        var personAsReadOnlyStruct3 = new PersonAsReadOnlyStruct()
        {
            Name = "Carmen",
            DateOfBirth = new DateOnly(2000, 01, 01)
        };
        //personAsReadOnlyStruct3.Name = "Carla";
        Console.WriteLine($"Inmutable (reandonly record struct): {personAsReadOnlyStruct3}");
        Console.WriteLine();
    }

    private record Persona(string Nombre, string[] Telefonos);
    private record Direccion(string City, string Calle);
    private record Cliente(string Nombre, string[] Telefonos,
        int LimiteCredito, Direccion Direccion) : Persona(Nombre, Telefonos);

    private static void ExampleWithInheritance()
    {
        var c1 = new Cliente("David", new string[] { "700123456" }, 1000,
            new Direccion("Santa Cruz", "Av. Beni"));
        var c2 = c1 with { };
        Console.WriteLine($"Cliente1 Telef.: {c1.Telefonos[0]}, Cliente2 Telef.: {c2.Telefonos[0]}");
        Console.WriteLine($"Cliente1 == Cliente2? {c1 == c2}");

        //c2.Direccion = new Direccion("", ""); 
        //c2.Direccion.Calle = "";
        //c2.Telefonos = new string[] { "700123456" };
        c2.Telefonos[0] = "700------";
        Console.WriteLine($"Cliente1 Telef.: {c1.Telefonos[0]}, Cliente2 Telef.: {c2.Telefonos[0]}");
        Console.WriteLine($"Cliente1 == Cliente2? {c1 == c2}");

        var c3 = new Cliente("Jesús", new string[] { "700123456" }, 1000, new Direccion("La Paz", "Av. Beni"));
        var c4 = new Cliente("Jesús", new string[] { "700123456" }, 1000, new Direccion("La Paz", "Av. Beni"));
        Console.WriteLine($"Cliente3 Telef.: {c3.Telefonos[0]}, Cliente4 Telef.: {c4.Telefonos[0]}");
        Console.WriteLine($"Cliente3 == Cliente4? {c3 == c4}");
    }

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Ejemplo con Records:", color);

        ExampleRecord();
        ExampleRecordStruct();
        ExampleWithInheritance();
    }
}
