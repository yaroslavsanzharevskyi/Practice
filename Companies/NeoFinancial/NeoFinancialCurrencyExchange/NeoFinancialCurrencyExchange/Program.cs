using System.Text;
using System.Text.Json;
using NeoFinancialCurrencyExchange;

// Read the JSON response from the API
var client = new HttpClient();

// Probably just put your seed in the URL
var response = await client.GetAsync("https://api-coding-challenge.neofinancial.com/currency-conversion?seed=87817");
var responseContent = await response.Content.ReadAsStringAsync();
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};
var exchangeRates = JsonSerializer.Deserialize<ExchangeRateEntry[]>(responseContent, options);

// Incase the API is down or the JSON response is not as expected
if (exchangeRates == null)
{
    throw new Exception("Unable to deserialize the JSON response");
}

var listOfCurrencies = new Dictionary<string, Currency>();
// Build the list of currencies and exchange rates as adjacency list
foreach (var exchangeRate in exchangeRates)
{
    if (!listOfCurrencies.TryGetValue(exchangeRate.FromCurrencyCode, out var currencyFrom))
    {
        currencyFrom = new Currency()
        {
            Code = exchangeRate.FromCurrencyCode,
            Name = exchangeRate.FromCurrencyName,
            ExchangeRateEntries = new List<ExchangeRateEntry>()
        };
        listOfCurrencies.Add(currencyFrom.Code, currencyFrom);
    }

    currencyFrom?.ExchangeRateEntries.Add(exchangeRate);

    if (!listOfCurrencies.TryGetValue(exchangeRate.ToCurrencyCode, out var currencyTo))
    {
        currencyTo = new Currency()
        {
            Code = exchangeRate.ToCurrencyCode,
            Name = exchangeRate.ToCurrencyName,
            ExchangeRateEntries = new List<ExchangeRateEntry>()
        };
        listOfCurrencies.Add(currencyTo.Code,currencyTo);
    }
}

var otherCurrencies = listOfCurrencies.Where(c => c.Key != "CAD").Select( c=> c.Value).ToArray();
var cadCurrency = listOfCurrencies["CAD"];

var listOfOptimalPaths = new List<List<Currency>>();
var solution = new Solution(listOfCurrencies);
foreach (var targetCurrency in otherCurrencies)
{
    // Build all paths
    var paths = solution.BuildPaths(cadCurrency, targetCurrency);
    if(paths.Count == 0){
        continue;
    }

    if(paths.Count > 1)
    {
        // Keep only the best path
        var bestPath = paths.OrderByDescending(p => solution.CalcExchangeAmount(p))?.First();
        listOfOptimalPaths.Add(bestPath);
    } else {
        listOfOptimalPaths.Add(paths[0]);
    }
}

// Calculate the amount of each currency
var pathsWithResultAmount = listOfOptimalPaths.ConvertAll(p => new
{
    Path = p,
    ResultAmount = solution.CalcExchangeAmount(p, 100)
});

// build the CSV file
var stringBuilder = new StringBuilder();
// Add the header
stringBuilder.AppendLine("Currency Code,Currency Name, Excchange Chain, Final Amount in Currency");

// Add the data
foreach (var pathWithResultAmount in pathsWithResultAmount)
{
    var currencyName = pathWithResultAmount.Path.Last().Name;
    var currencyCode = pathWithResultAmount.Path.Last().Code;
    var exchangeChain = string.Join(" | ", pathWithResultAmount.Path.Select(p => p.Code));
    var finalAmount = pathWithResultAmount.ResultAmount; // not rounding to 2 digits since Digital Currencies like BT have very high precision 
    stringBuilder.AppendLine($"{currencyName},{currencyCode},{exchangeChain},\"{finalAmount}\"");
}

// Write the CSV file
File.WriteAllText("./exchange-table.csv", stringBuilder.ToString());
