using System.Text;

namespace D05_MethodChaining
{
    internal class SelectBox3
    {
        private static Func<IDictionary<int, string>, string> Build(
            string id, bool includeUnknown) =>
            options =>
            new StringBuilder()
                .AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id)
                .When(
                    () => includeUnknown,
                    sb => sb.AppendLine("\t<option>Unknown</option>"))
                .AppendSequence(
                    options,
                    (sb, opt) => sb.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value))
                .AppendLine("</select>")
                .ToString();

        public static void Show()
        {
            // Transformation Pipeline
            Disposable
                .Using(
                    () => StreamFactory.GetStream(),
                    stream => new byte[stream.Length]
                            .Tee(buffer => stream.Read(buffer, 0, (int)stream.Length)))
                .Map(Encoding.UTF8.GetString)
                .Split(new[] { Environment.NewLine, }, StringSplitOptions.RemoveEmptyEntries)
                .Select((s, ix) => Tuple.Create(ix, s))
                .ToDictionary(k => k.Item1, v => v.Item2)
                .Map(Build("theDoctors", true))
                .Tee(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
