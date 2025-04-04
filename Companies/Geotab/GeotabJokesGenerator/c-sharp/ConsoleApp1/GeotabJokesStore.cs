using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JokeGenerator;

public interface IJokeStore
{
    Task<string[]> GetRandomJokes(string category, int numberOfJokes);
    Task<string[]> GetCategories();
}

public class GeotabJokesStore : IJokeStore
{
    private readonly HttpClient client;

    public GeotabJokesStore(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient("geotabStore");
    }

    public async Task<string[]> GetRandomJokes(string category, int numberOfJokes)
    {
        try
        {
            string query = string.IsNullOrWhiteSpace(category) ? string.Empty : $"?category={category}";
            string url = $"{Endpoints.jokes}{query}";

            // Create a list of tasks
            var tasks = Enumerable.Range(1, numberOfJokes).Select(i => client.GetStringAsync(url));

            // Await the completion of all tasks asynchronously
            var result = await Task.WhenAll(tasks);
            var anonymousType = new { value = string.Empty };
            return result.Select(joke => JsonConvert.DeserializeAnonymousType(joke, anonymousType).value).ToArray();
        }
        catch (HttpRequestException)
        {
            return new string[] { "Error fetching jokes." };
        }
        catch (JsonException)
        {
            return new string[] { "Error deserializing joke data. " };
        }
        catch (Exception)
        {
            return new string[] { "An unexpected error occurred. " };
        }
    }

    public async Task<string[]> GetCategories()
    {
        try
        {
            var result = await client.GetStringAsync(Endpoints.categories);
            return JsonConvert.DeserializeObject<string[]>(result);
        }
        catch (HttpRequestException)
        {
            return new string[] { "Error fetching categories." };
        }
        catch (JsonException)
        {
            return new string[] { "Error deserializing categories data. " };
        }
        catch (Exception)
        {
            return new string[] { "An unexpected error occurred. " };
        }
    }

    class Endpoints
    {
        public static readonly string categories = "joke_category";
        public static readonly string jokes = "joke";
    }
}