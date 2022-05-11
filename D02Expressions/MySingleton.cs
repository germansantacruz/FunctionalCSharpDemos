namespace D02Expressions;

internal class MySingleton
{
    private static MySingleton instance;

    private MySingleton() { }

    public static MySingleton Instance
        => instance ??= new MySingleton();

    public override string ToString()
        => $"Type name: {GetType().Name.Split('+')[0]}";
}
