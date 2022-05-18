using System.Text;
namespace D01Introduction.FPCSharp;

public static class F07_Records
{
    // *******************************************************************************
    //                              **Type**            **Positional properties**
    // record | record class        Por referencia      Inmutables
    // record struct                Por valor           Mutables
    // readonly record struct       Por valor           Inmutables
    //
    // Records: Tipos inmutables con soporte para crear versiones modificadas.
    //          - Los datos a los que hace referencia una propiedad de tipo de referencia
    //            se pueden cambiar.
    //          - La copia con with es una copia superficial, es decir que para una
    //            propiedad de referencia, solo se copia la referencia a la instancia.
    //            Tanto el registro original como la copia terminan con una referencia
    //            a la misma instancia.
    // *******************************************************************************

    // Records inmutables
    private record Person(string Name, DateOnly DateOfBirth);
    private record Client(int CreditLimit, string Group, string Name, DateOnly DateOfBirth)
        : Person(Name, DateOfBirth);

    // El record puede ser mutable reemplazando set por init
    private record Person2
    {
        public string Name { get; init; } = default!;
        public DateOnly DateOfBirth { get; set; }

        protected virtual bool PrintMembers(StringBuilder builder)
        {
            builder.Append("Print Custom: ");
            builder.Append($"({Name}, {DateOfBirth})");
            return true;
        }
    }

    private static void ExamplesWithRecord()
    {
        var david = new Person("David", new DateOnly(2000, 01, 01));
        // Clonar registro
        var david2 = david with { };
        var client = new Client(1000, "Mayorista", david.Name, david.DateOfBirth);

        // ***************************************************************************
        // VERIFICANDO LA INMUTABILIDAD
        // ***************************************************************************
        //david2.Name = "";                                 // Inmutable
        //david2.DateOfBirth = new DateOnly(2000, 01, 01);  // Inmutable
        //client.Name = "";                                 // Inmutable
        var person2 = new Person2();
        //person2.Name = "";                                // Inmutable (init)
        person2.DateOfBirth = new DateOnly(2000, 01, 01);   // Mutable (set)

        // Print con formato especial
        Console.WriteLine(david);
        Console.WriteLine(client);

        // Igualdad estructural
        Console.WriteLine($"Record David == Record David2? {david == david2}");
        // Igualdad referencial
        Console.WriteLine($"Record David ==Ref Record David2? {ReferenceEquals(david, david2)}");

        // Clonar
        var davidOlder = david with { DateOfBirth = new DateOnly(1999, 01, 01) };
        Console.WriteLine($"Clone David Older {davidOlder}");

        // Desconstrucción del registro
        var (name, dateOfBirth) = david;
        Console.WriteLine($"Desconstrucción: Name: {name}, DateOfBirth: {dateOfBirth}");

        // Custom Print
        Console.WriteLine(person2);
        Console.WriteLine();
    }

    private record struct PersonAsStruct(string Name, DateOnly DateOfBirth);
    private readonly record struct PersonAsReadOnlyStruct(string Name, DateOnly DateOfBirth);

    private static void ExamplesWithRecordStruct()
    {
        // Mutable              record struct
        var personAsStruct = new PersonAsStruct("", DateOnly.MinValue);
        personAsStruct.Name = "Alex";                               // Mutable
        personAsStruct.DateOfBirth = new DateOnly(1980, 05, 16);    // Mutable
        Console.WriteLine($"Mutable (record struct): {personAsStruct}");

        var personAsStruct2 = personAsStruct with { };
        personAsStruct2.Name = "AlexClone";
        Console.WriteLine($"Mutable clone (record struct): {personAsStruct2}");

        // Inmutable            readonly record struct
        var personAsReadOnlyStruct = new PersonAsReadOnlyStruct();
        //personAsReadOnlyStruct.Name = "";                         
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
        Console.WriteLine(c3);
        Console.WriteLine($"Cliente3 == Cliente4? {c3 == c4}");
    }

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Ejemplos con Records:", color);

        ExamplesWithRecord();
        ExamplesWithRecordStruct();
        ExampleWithInheritance();
    }
}
