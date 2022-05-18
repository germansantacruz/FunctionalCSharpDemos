namespace D01Introduction.FPCSharp;

public static class F03_ExpressionBodiedMembers
{
    // *******************************************************************************    
    // Funciones y propiedades más concisas con expression-bodied members
    // *******************************************************************************

    private class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public string FullNameProp => string.Concat(FirstName, " ", LastName)
                                    .ToUpper();
        public string FullNameMethod() => string.Concat(FirstName, " ", LastName)
                                     .ToUpper();

    }
    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Ejemplo con Expression-bodied Members:", color);

        //Person p = new("", "") { FirstName = "" };
        Person p = new("Tomasa", "Tellez");
        Console.WriteLine(p.FullNameProp);
        Console.WriteLine(p.FullNameMethod());
    }
}
