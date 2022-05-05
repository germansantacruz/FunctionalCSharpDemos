namespace D03Expresiones;

internal class Time3
{
    public async static Task<string> Get(string country)
    {
        string url = $"https://www.google.com/search?q={country}+time";

        var response = Disposable.UsingAsync(
            () => new HttpClient(),
            async client => await client.GetAsync(url)).Result;

        string result = await response.Content.ReadAsStringAsync();

        var ind = result.IndexOf("BNeawe iBp4i AP7Wnd");
        return ind <= 0 ? "Time not found." : result.Substring(ind + 59, 5);
    }
}
