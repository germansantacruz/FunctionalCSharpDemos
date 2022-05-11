namespace D01Introduction;

public static class Ex03_Concurrency
{
    public static void MutarEstadoOcasionaProblemas()
    {
        // Problemas en procesos concurrentes
        var numeros = Enumerable.Range(-10000, 20001).Reverse().ToArray();
        // => [10000, -10000]

        var task1 = () => Console.WriteLine($"Tarea 1: {numeros.Sum()}");
        var task2 = () =>
        {
            Array.Sort(numeros);
            Console.WriteLine(numeros.Sum());
        };

        Parallel.Invoke(task2, task1);
        // print: 0
        // print: un valor no predecible porque Task2 modifica el Array
    }

    // El uso de LINQ brinda un resultado predecible,
    // incluso cuando se ejecuta las tareas en paralelo.
    public static void SinMutarEstado()
    {
        // Problemas en procesos concurrentes
        var numeros = Enumerable.Range(-10000, 20001).Reverse().ToArray();
        // => [10000, -10000]

        var task1 = () => Console.WriteLine(numeros.Sum());
        var task2 = () => Console.WriteLine(numeros.OrderBy(x => x).Sum());

        Parallel.Invoke(task1, task2);
        // print: 0
        // print: 0
    }
}
