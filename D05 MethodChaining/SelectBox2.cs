using System.Text;

namespace D05_MethodChaining
{
    internal class SelectBox2
    {
        private static string Build(IDictionary<int, string> options,
            string id, bool includeUnknown) =>
            new StringBuilder()
                .AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id)
                .AppendWhen(
                    () => includeUnknown,
                    sb => sb.AppendLine("\t<option>Unknown</option>"))
                .AppendSequence(
                    options,
                    (sb, opt) => sb.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value))
                .AppendLine("</select>")
                .ToString();

        public static void Show()
        {
            using var stream = StreamFactory.GetStream();
            var selectBox = stream
                .Map(st => new byte[st.Length]
                            .Tee(buffer => st.Read(buffer, 0, (int)st.Length)))
                .Map(Encoding.UTF8.GetString)
                .Split(new[] { Environment.NewLine, }, StringSplitOptions.RemoveEmptyEntries)
                .Select((s, ix) => Tuple.Create(ix, s))
                .ToDictionary(k => k.Item1, v => v.Item2)
                .Map(options => Build(options, "theDoctors", true))
                .Tee(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
