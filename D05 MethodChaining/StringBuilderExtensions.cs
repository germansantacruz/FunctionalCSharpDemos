using System.Text;

namespace D05_MethodChaining;

public static class StringBuilderExtensions
{
    public static StringBuilder AppendFormattedLine(
        this StringBuilder @this,
        string format,
        params object[] args) =>
            @this.AppendFormat(format, args).AppendLine();

    public static StringBuilder AppendWhen(
        this StringBuilder sb,
        Func<bool> predicate,
        Func<StringBuilder, StringBuilder> fn) =>
            predicate() ? fn(sb) : sb;

    public static StringBuilder AppendSequence<T>(
        this StringBuilder sb,
        IEnumerable<T> sequence,
        Func<StringBuilder, T, StringBuilder> fn) =>
            sequence.Aggregate(sb, fn);
}
