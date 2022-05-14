namespace D05Functions;

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
        Console.WriteLine("1. Higher-order function     2. Inmutabilidad      3. Concurrencia");
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
                    HOFs.RunExample(color);
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
