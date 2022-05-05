namespace D03Expresiones;

public static class Disposable
{
    public static async Task<TResult> UsingAsync<TDisposable, TResult>(
        Func<TDisposable> factory,
        Func<TDisposable, Task<TResult>> map)
        where TDisposable : IDisposable
    {
        using var disposable = factory();
        return await map(disposable);
    }
}
