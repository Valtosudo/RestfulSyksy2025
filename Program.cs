using System.Net.Http.Headers;


namespace RestfulSyksy2025;

class Program
{
    static async Task Main(string[] args)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            await GetItemsAsync(client);
        }
    }

    static async Task GetItemsAsync(HttpClient client)
    {
        var response = await client.GetAsync("https://api.restful-api.dev/objects");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine(json);
            return;
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return;
        }
    }
}
