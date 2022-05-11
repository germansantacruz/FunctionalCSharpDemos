using static System.Math;

namespace D01Introduction;

public static class Ex04_FunctionalCSharp
{
    public record Circle(double radius)
    {
        public double Circumference => PI * 2 * radius;
    }

    // *****************************************
    // Init only setters
    // *****************************************
    public class PruebaInitOnlySetters
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
}
