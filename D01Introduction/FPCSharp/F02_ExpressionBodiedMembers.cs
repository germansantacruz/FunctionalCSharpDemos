namespace D01Introduction.FPCSharp;

public static class F02_ExpressionBodiedMembers
{
    // Funciones más concisas con expression-bodied members 
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
    public static void Example()
    {
        Console.WriteLine("\nF02 ==> Ejemplo con Expression-bodied Members.");
        //Person p = new("", "") { FirstName = "" };
        Person p = new("Tomasa", "Tellez");
        Console.WriteLine(p.FullNameProp);
        Console.WriteLine(p.FullNameMethod());
    }
}
