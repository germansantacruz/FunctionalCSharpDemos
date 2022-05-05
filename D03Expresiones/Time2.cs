namespace D03Expresiones;

internal class Time2
{
    public async static Task<string> Get(string country)
    {
        string url = $"https://www.google.com/search?q={country}+time";

        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        string result = await response.Content.ReadAsStringAsync();

        var ind = result.IndexOf("BNeawe iBp4i AP7Wnd");
        return ind <= 0 ? "Time not found." : result.Substring(ind + 59, 5);
    }
}
