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
        Console.WriteLine("1. Imperativa vs Funcional     2. Inmutabilidad      3. Concurrencia");
        Console.WriteLine("4. Preferir expresiones        5. Init only setters  6. LINQ");
        Console.WriteLine("7. Expression Bodied Members   8. Funciones locales  9. Tuplas");
        Console.WriteLine("10. Pattern Matching");
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
                    Ex04_Expressions.RunExample(color);
                    break;
                case "5":
                    F05_InitOnlySetters.RunExample(color);
                    break;
                case "6":
                    F01_LINQ.RunExample(color);
                    break;
                case "7":
                    F02_ExpressionBodiedMembers.RunExample(color);
                    break;
                case "8":
                    F03_FunctionsWithinFunctions.RunExample(color);
                    break;
                case "9":
                    F04_Tuples.RunExample(color);
                    break;
                case "10":
                    F06_PatternMatching.RunExample(color);
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
