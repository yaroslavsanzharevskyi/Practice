using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}

public class SearchResult
{
    public Customer Customer { get; set; }
    public int Score { get; set; }
}

class Solution {
    static void Main(string[] args) {
        using var stdinStream = Console.OpenStandardInput();
        using var stdin = new StreamReader(stdinStream);
        var lines = stdin.ReadToEnd().Split(Environment.NewLine)
            .Select(l => {
                return l.Split(',');
            })
            .ToList();

        var weights = lines.Where(l => l[0] == "weight")
            .ToDictionary(x => x[1], x => int.Parse(x[2]));

        var customers = lines.Where(l => l[0] == "customer")
            .Select(l => new Customer {
                FirstName = l[1],
                LastName = l[2],
                Address = l[3]
            })
            .ToList();
        
        var searchString = lines.Where(l => l[0] == "search")
            .Select(l => l[1])
            .First();
            
        // perform the search
        var searchResults = Search(weights, customers, searchString);

        // display the results
        foreach (var result in searchResults)
        {
            Console.WriteLine($"{result.Customer.FirstName} {result.Customer.LastName} {result.Customer.Address} - Score: {result.Score}");
        }
    }
    
    static int ContainsCalc(string actual, string search, int weight)
    {
        
        if (actual.Length < search.Length)
        {
            return 0;
        }
        
        if(actual.Contains(search,StringComparison.OrdinalIgnoreCase))
        {
            return actual.Length == search.Length? weight * 2: weight;
        }
        
        return 0;
        
    }
    
    static List<SearchResult> Search(Dictionary<string, int> weights, List<Customer> customers, string searchString)
    {
        var tokens = TokenizeSearchString(searchString);
        
        // Calculate score for each customer
        var results = customers.Select(c => {
            var maxScoreFirstName = 0;
            var maxScoreLastName = 0;
            var maxScoreAddress = 0;
            
            // Check if full search string is contained (4x weight)
            if (c.FirstName.Contains(searchString,StringComparison.OrdinalIgnoreCase))
                maxScoreFirstName = weights[nameof(c.FirstName).ToLower()] * 4;
                
            if (c.LastName.Contains(searchString,StringComparison.OrdinalIgnoreCase))
                maxScoreLastName = weights[nameof(c.LastName).ToLower()] * 4;
                
            if (c.Address.Contains(searchString,StringComparison.OrdinalIgnoreCase))
                maxScoreAddress = weights[nameof(c.Address).ToLower()] * 4;
                
            // Check each token
            tokens.ForEach(token => {
                var curFirstNameScore = 0;
                var curLastNameScore = 0;
                var curAddressScore = 0;
                
                curFirstNameScore = ContainsCalc(c.FirstName, token, weights[nameof(c.FirstName).ToLower()]);
                maxScoreFirstName = Math.Max(maxScoreFirstName, curFirstNameScore);
                
                curLastNameScore = ContainsCalc(c.LastName, token, weights[nameof(c.LastName).ToLower()]);
                maxScoreLastName = Math.Max(maxScoreLastName, curLastNameScore);
                
                curAddressScore = ContainsCalc(c.Address, token, weights[nameof(c.Address).ToLower()]);
                maxScoreAddress = Math.Max(maxScoreAddress, curAddressScore);  
            });
            
            
            return new SearchResult{
                Customer = c,
                Score = maxScoreFirstName + maxScoreLastName + maxScoreAddress
            };
        })
        .OrderByDescending(c => c.Score)
        .Take(5)
        .ToList();
        
        return results;
    }

    static List<string> TokenizeSearchString(string searchString)
    {
        // tokenize the search string
        return searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(token => token.Length >= 3)
            .ToList();
    }
}
