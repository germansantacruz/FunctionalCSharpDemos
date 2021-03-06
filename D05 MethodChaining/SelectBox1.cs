using System.Text;

namespace D05_MethodChaining
{
    internal class SelectBox1
    {
        private static string Build(IDictionary<int, string> options,
            string id, bool includeUnknown)
        {
            var html = new StringBuilder();
            html.AppendFormat("<select id=\"{0}\" name=\"{0}\">", id);
            html.AppendLine();

            if (includeUnknown)
            {
                html.AppendLine("\t<option>Unknown</option>");
            }

            foreach (var opt in options)
            {
                html.AppendFormat("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value);
                html.AppendLine();
            }

            html.AppendLine("</select>");

            return html.ToString();
        }

        public static void Show()
        {
            byte[] buffer;

            using (var stream = StreamFactory.GetStream())
            {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
            }

            var options =
                Encoding
                    .UTF8
                    .GetString(buffer)
                    .Split(new[] { Environment.NewLine, }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, ix) => Tuple.Create(ix, s))
                    .ToDictionary(k => k.Item1, v => v.Item2);

            var selectBox = Build(options, "theDoctors", true);

            Console.WriteLine(selectBox);
            Console.ReadLine();
        }
    }
}
