using Microsoft.Data.SqlClient;
namespace D05Functions;

public static class HOFs
{
    // Higher-order functions
    // Las HOF son funciones que toman otras funciones como entradas
    // o devuelven una función como salida o ambas.

    private static decimal Divide(decimal n1, decimal n2) => n1 / n2;

    private static Func<decimal, decimal, decimal> GetOperation(char oper)
        => oper switch
        {
            '+' => (l, r) => l + r,
            '-' => (l, r) => l - r,
            '*' => (l, r) => l * r,
            '/' => Divide,
            _ => throw new NotSupportedException("The supplied operator is not supported.")
        };

    private static void Example1()
    {
        Console.Write("Choose an operation (+, -, *, /): ");
        var operation = Console.ReadLine() ?? " ";

        Console.Write("Digit Number1: ");
        decimal n1 = decimal.Parse(Console.ReadLine() ?? "0");
        Console.Write("Digit Number2: ");
        decimal n2 = decimal.Parse(Console.ReadLine() ?? "0");

        decimal result = GetOperation(operation[0])(n1, n2);

        Console.WriteLine($"Result is: {result:0.00}");
    }

    // Adapter functions
    // Algo similar al patrón adapter en POO
    private static Func<T2, T1, R> SwapArgs<T1, T2, R>(this Func<T1, T2, R> func)
        => (t2, t1) => func(t1, t2);

    // Negar un predicado
    private static Func<T, bool> Negate<T>(this Func<T, bool> predicate)
        => t => !predicate(t);

    // Using
    private static async Task<TResult> UsingAsync<TDisposable, TResult>(
        Func<TDisposable> factory,
        Func<TDisposable, Task<TResult>> map)
        where TDisposable : IDisposable
    {
        using var disposable = factory();
        return await map(disposable);
    }

    private static void Example2()
    {
        var divide = Divide;
        var divideBy = divide.SwapArgs();

        Console.WriteLine($"10 / 2 =  {divide(10, 2)}");
        Console.WriteLine($"10 / 2 =  {divideBy(2, 10)}");

        var pares = (int number) => number % 2 == 0;
        var data = Enumerable.Range(1, 10)
            .Where(pares.Negate())
            .ToArray();

        Console.WriteLine($"Números impares del 1 al 10: {string.Join(" ", data)}");
    }

    // Avoid duplication (setup and dispose)
    private static async Task ExecuteSqlTransaction(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            SqlCommand command = connection.CreateCommand();

            // Start a local transaction.
            SqlTransaction transaction = null;
            transaction = await Task.Run(
                () => connection.BeginTransaction("SampleTransaction"));

            command.Connection = connection;
            command.Transaction = transaction;

            try
            {
                command.CommandText = "Insert into ...";
                await command.ExecuteNonQueryAsync();

                command.CommandText = "Insert into ...";
                await command.ExecuteNonQueryAsync();

                await Task.Run(() => transaction.Commit());
                Console.WriteLine("Both records are written to database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("  Message: {0}", ex.Message);

                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    // Errors about a closed connection.                   
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }
        }
    }

    private static async Task<R> Connect<R>(string connectionString, Func<SqlCommand, Task<R>> func)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            return await UsingAsync(() => connection.CreateCommand(),
                async cmd =>
                {
                    cmd.Connection = connection;
                    return await func(cmd);
                });
        }
    }

    private static Task<int> Insert(int id, string cnn)
    => Connect(cnn, async cmd =>
        {
            try
            {
                cmd.CommandText = $"insert into values({id})";
                return await cmd.ExecuteNonQueryAsync();
            }
            catch { return 0; }
        });

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Ejemplos de HOFs:", color);

        Example1();
        Example2();
    }
}
