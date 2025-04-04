using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace JokeGenerator;

public class Program
{
    static char key;
    static string[] availableCategories;

    static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection()
                .AddSingleton<IJokeStore, GeotabJokesStore>();

        serviceCollection.AddHttpClient(
            "geotabStore",
            (sp, client) =>
            {
                client.BaseAddress = new Uri("https://us-central1-geotab-interviews.cloudfunctions.net/");
            }
        );

        var sp = serviceCollection.BuildServiceProvider();
        await Run(sp.GetService<IJokeStore>());
    }

    public static async Task Run(IJokeStore store)
    {
        Console.WriteLine("Press ? to get instructions.");
        var enableLoop = true;
        while (enableLoop)
        {
            key = Console.ReadLine()?.FirstOrDefault() ?? '\0';

            switch (key)
            {
                case '?':
                    {
                        Console.WriteLine("Press c to get categories");
                        Console.WriteLine("Press r to get random jokes");
                        Console.WriteLine("Press q to quit");
                        break;
                    }
                case 'c':
                    {
                        if (availableCategories == null)
                        {
                            availableCategories = await store.GetCategories();
                        }

                        PrintResults(availableCategories);
                        break;
                    }
                case 'r':
                    {
                        var category = string.Empty;

                        Console.WriteLine("Want to specify a category? y/n");
                        key = Console.ReadLine()?.FirstOrDefault() ?? '\0';

                        if (key == 'y')
                        {
                            Console.WriteLine("Enter a category.");
                            category = Console.ReadLine();

                            if (availableCategories == null)
                            {
                                availableCategories = await store.GetCategories();
                            }

                            while (!availableCategories.Contains(category))
                            {
                                Console.WriteLine($"You've entered a wrong category. Please enter a one of this {string.Join(',', availableCategories)}");
                                category = Console.ReadLine();
                            }
                        }

                        Console.WriteLine("How many jokes do you want? (1-9)");
                        int n = Int32.Parse(Console.ReadLine());

                        while (n < 1 || n > 9)
                        {
                            Console.WriteLine("You've entered a wrong number. Please enter a number between 1 and 9.");
                            n = Int32.Parse(Console.ReadLine());
                        }

                        var jokes = await store.GetRandomJokes(category, n);
                        PrintResults(jokes);
                        break;
                    }
                case 'q':
                    {
                        enableLoop = false;
                        break;
                    }
            }
        }
    }

    private static void PrintResults(string[] lines)
    {
        foreach (var line in lines)
        {
            Console.WriteLine($"[{line}]");
        }
    }
}

