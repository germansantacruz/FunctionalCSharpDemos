namespace D01Introduction;

public static class Ex04_Expressions
{
    private class MyClassicSingleton
    {
        private static MyClassicSingleton instance;

        private MyClassicSingleton() { }

        public static MyClassicSingleton Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new MyClassicSingleton();
                }

                return instance;
            }
        }
        // Other stuff here
    }

    // Las expresiones se ejecutan por su resultado.
    private class MySingleton
    {
        private static MySingleton instance;

        private MySingleton() { }

        public static MySingleton Instance => instance ??= new MySingleton();

        public override string ToString()
            => $"Type name: {GetType().Name.Split('+')[0]}";
    }

    public static void RunExample(ConsoleColor color)
    {
        Util.ShowTitle("Preferir expresiones sobre declaraciones:", color);

        var instance1 = MyClassicSingleton.Instance;
        var instance2 = MyClassicSingleton.Instance;
        Console.WriteLine($"Same Object? {ReferenceEquals(instance1, instance2)}");

        var instance3 = MySingleton.Instance;
        var instance4 = MySingleton.Instance;
        Console.WriteLine($"Same Object? {ReferenceEquals(instance3, instance4)}");
    }
}