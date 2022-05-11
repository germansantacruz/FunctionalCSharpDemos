namespace D02Expressions;

internal class MyClassicSingleton
{
    private static MyClassicSingleton instance;

    private MyClassicSingleton()
    {
    }

    public static MyClassicSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MyClassicSingleton();
            }

            return instance;
        }
    }

    // Other stuff here
}
