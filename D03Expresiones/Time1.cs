namespace D03Expresiones;

internal class Time1
{
    public async static Task<string> Get(string country)
    {
        string url = $"https://www.google.com/search?q={country}+time";
        string result;

        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            result = await response.Content.ReadAsStringAsync();
        }

        string searchCriteria = "BNeawe iBp4i AP7Wnd";
        var ind = result.IndexOf(searchCriteria);

        if (ind == -1 || ind == 0)
            return "Time not found.";
        else
            return result.Substring(ind + 59, 5);
    }
}
