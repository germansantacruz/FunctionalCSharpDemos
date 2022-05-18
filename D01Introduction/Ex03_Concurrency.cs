namespace D01Introduction;

public static class Ex03_Concurrency
{
    // *******************************************************************************    
    // Si existe mutación de estado, no se puede garantizar el resultado en procesos
    // concurrentes.
    // *******************************************************************************

    private static void MutarEstado()
    {
        // Problemas en procesos concurrentes
        var numeros = Enumerable.Range(-10000, 20001).Reverse().ToArray();
        // => [10000, -10000]

        var task1 = () => Console.WriteLine($"Task 1: {numeros.Sum()}");
        var task2 = () =>
        {
            Array.Sort(numeros);
            Console.WriteLine($"Task 2: {numeros.Sum()}");
        };

        Parallel.Invoke(task2, task1);
        // Task 1 print: un valor no predecible porque Task2 modifica el Array
        // Task 2 print: 0
    }

    // El uso de LINQ brinda un resultado predecible,
    // incluso cuando se ejecuta las tareas en paralelo.
    private static void SinMutarEstado()
    {
        var numeros = Enumerable.Range(-10000, 20001).Reverse().ToArray();

        var task1 = () => Console.WriteLine($"Task 1: {numeros.Sum()}");
        var task2 = () => Console.WriteLine($"Task 2: {numeros.OrderBy(x => x).Sum()}");

        Parallel.Invoke(task1, task2);
        // print: 0
        // print: 0
    }

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Evitar mutación de estado en procesos concurrentes:", color);

        MutarEstado();
        SinMutarEstado();
    }
}