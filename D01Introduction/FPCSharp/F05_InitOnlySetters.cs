namespace D01Introduction.FPCSharp;

public static class F05_InitOnlySetters
{
    private class PruebaInitOnlySetters
    {
        // Propiedad de sólo lectura
        // Se puede asignar un valor en la inicialización al instanciar con new {}
        // También se puede asignar un valor en el constructor
        public int Id { get; init; } = 1;

        public PruebaInitOnlySetters()
        { }

        public PruebaInitOnlySetters(int id)
        {
            Id = id;
        }
    }

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Ejemplo de Init only setters:", color);

        PruebaInitOnlySetters c2 = new();
        Console.WriteLine($"Valor de Id: {c2.Id}");
        //c2.Id = 10;
        PruebaInitOnlySetters c3 = new(3);
        Console.WriteLine($"Valor de Id: {c3.Id}");
        PruebaInitOnlySetters c4 = new() { Id = 10 };
        Console.WriteLine($"Valor de Id: {c4.Id}");
    }
}
