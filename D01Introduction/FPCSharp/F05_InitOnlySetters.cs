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
        Util.ShowTitle("Ejemplo con Tuplas:", color);


    }
}
