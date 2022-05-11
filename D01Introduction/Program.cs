using D01Introduction;

Console.Title = "Ejemplos de Programación Funcional en C#";
PrintMenu();
RunExamples();


/*

// C Sharp Funcional
Console.Write("******************************************************************\n");
Console.WriteLine("¿Cuán funcional es C Sharp?");
Console.Write("******************************************************************\n");

F01_LINQ.Example();
F02_ExpressionBodiedMembers.Example();
F03_FunctionsWithinFunctions.Example();
F04_Tuples.Example();

/*
Ex04_FunctionalCSharp.Circle c1 = new Ex04_FunctionalCSharp.Circle(10.2);
Console.WriteLine(c1.Circumference);

// *********************************
// Init only setters
// *********************************
Console.WriteLine("\nPrueba de Init only setters:");
Ex04_FunctionalCSharp.PruebaInitOnlySetters c2 = new();
Console.WriteLine($"Valor de Id: {c2.Id}");
//c2.Id = 10;
Ex04_FunctionalCSharp.PruebaInitOnlySetters c3 = new(3);
Console.WriteLine($"Valor de Id: {c3.Id}");
Ex04_FunctionalCSharp.PruebaInitOnlySetters c4 = new() { Id = 10 };
Console.WriteLine($"Valor de Id: {c4.Id}");
*/

static void PrintMenu()
{
    Console.WriteLine("****************************************************************");
    Console.WriteLine("                              Menú");
    Console.WriteLine("****************************************************************");
    Console.WriteLine("1. Imperativa vs Funcional   2. Inmutabilidad    3. Concurrencia");
    Console.WriteLine("Elija una opción.");
}

static void RunExamples()
{
    var color = ConsoleColor.DarkGreen;
    var op = "_";
    while (op != "exit")
    {
        Console.Write("\n===> ");
        op = Console.ReadLine() ?? "";

        switch (op)
        {
            case "1":
                Ex01_ImperativaVsFunc.RunExample(color);
                break;
            case "2":
                Ex02_Immutability.RunExample(color);
                break;
            case "3":
                Ex03_Concurrency.RunExample(color);
                break;
            case "clear":
                Console.Clear();
                PrintMenu();
                break;
            default:
                op = "exit";
                break;
        }
    }
}
