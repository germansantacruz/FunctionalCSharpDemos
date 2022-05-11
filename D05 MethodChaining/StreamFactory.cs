using System.Text;

namespace D05_MethodChaining;

public static class StreamFactory
{
    private static string GetLines() =>
            string.Join(
                Environment.NewLine,
                new[] {
                    "Hartnell", "Troughton", "Pertwee", "T. Baker",
                    "Davison", "C. Baker", "McCoy", "McGann", "Hurt",
                    "Eccleston", "Tennant", "Smith", "Capaldi" });

    /*
    public static Stream GetStream()
    {
        var doctors = GetLines();
        var buffer = Encoding.UTF8.GetBytes(doctors);

        var stream = new MemoryStream();
        stream.Write(buffer, 0, buffer.Length);
        stream.Position = 0L;

        return stream;
    }*/

    public static Stream GetStream()
    {
        var doctors = GetLines();
        var buffer = Encoding.UTF8.GetBytes(doctors);

        return new MemoryStream()
            .Tee(stream =>
            {
                stream.Write(buffer, 0, buffer.Length);
                stream.Position = 0L;
            });
    }
}
