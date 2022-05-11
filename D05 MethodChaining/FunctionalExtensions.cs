namespace D05_MethodChaining;

public static class FunctionalExtensions
{
    public static TResult Map<TSource, TResult>(
      this TSource @this,
      Func<TSource, TResult> fn) => fn(@this);

    public static T Tee<T>(this T obj, Action<T> action)
    {
        action(obj);
        return obj;
    }

    public static T When<T>(
          this T @this,
          Func<bool> predicate,
          Func<T, T> fn) => predicate() ? fn(@this) : @this;
}
