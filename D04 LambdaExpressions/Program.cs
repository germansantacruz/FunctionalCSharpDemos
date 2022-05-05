static Func<decimal, decimal, decimal> GetOperation(char oper)
{
    switch (oper)
    {
        case '+': return (l, r) => l + r;
        case '-': return (l, r) => l - r;
        case '*': return (l, r) => l * r;
        case '/': return (l, r) => l / r;
    }

    throw new NotSupportedException("The supplied operator is not supported.");
}

Console.Write("Choose an operation (+, -, *, /): ");
var operation = Console.ReadLine() ?? " ";

Console.Write("Digit Number1: ");
decimal n1 = decimal.Parse(Console.ReadLine() ?? "0");
Console.Write("Digit Number2: ");
decimal n2 = decimal.Parse(Console.ReadLine() ?? "0");

decimal result = GetOperation(operation[0])(n1, n2);

Console.WriteLine($"Result is: {result:0.00}");
Console.ReadLine();
