using D01Introduction.FPCSharp;
namespace D01Introduction;

public static class Util
{
    public static void ShowTitle(string title, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"\n{title}");
        Console.WriteLine("-----------------------------------------------------\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void PrintMenu()
    {
        Console.WriteLine("****************************************************************");
        Console.WriteLine("                              Menú");
        Console.WriteLine("****************************************************************");
        Console.WriteLine("1. Imperativa vs Funcional     2. Inmutabilidad    3. Concurrencia");
        Console.WriteLine("4. Expression Bodied Members   5. LINQ             6. Funciones locales");
        Console.WriteLine("7. Tuplas");
        Console.WriteLine("Elija una opción.");
    }

    public static void RunExamples()
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
                case "4":
                    F02_ExpressionBodiedMembers.RunExample(color);
                    break;
                case "5":
                    F01_LINQ.RunExample(color);
                    break;
                case "6":
                    F03_FunctionsWithinFunctions.RunExample(color);
                    break;
                case "7":
                    F04_Tuples.RunExample(color);
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
}
