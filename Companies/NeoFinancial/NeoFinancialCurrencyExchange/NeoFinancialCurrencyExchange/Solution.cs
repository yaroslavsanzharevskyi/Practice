namespace NeoFinancialCurrencyExchange;

public class Solution
{
    private readonly Dictionary<string, Currency> _dictOfCurrencies;

    public Solution(Dictionary<string, Currency> listOfCurrencies)
    {
        _dictOfCurrencies = listOfCurrencies;
    }

    public List<List<Currency>> BuildPaths(Currency current, Currency target)
    {
        var resultingPaths = new List<List<Currency>>();
        foreach (var link in current.ExchangeRateEntries)
        {
            var dictWithInitialVisit = new HashSet<Currency>()
            {
                {current}
            };

            var linkedCurrency = _dictOfCurrencies[link.ToCurrencyCode];
            var path = new List<Currency>
            {
                current
            };

            BuildPaths(path, linkedCurrency, target, dictWithInitialVisit, resultingPaths);
        }

        return resultingPaths;
    }

    private void BuildPaths(List<Currency> currentPath, Currency current, Currency targetNode, HashSet<Currency> visited, List<List<Currency>> paths)
    {
        currentPath.Add(current);
        if (current.Code == targetNode.Code)
        {
            paths.Add(currentPath);
        }
        else
        {
            visited.Add(current);
        }

        foreach (var link in current.ExchangeRateEntries)
        {
            var linkedCurrency = _dictOfCurrencies[link.ToCurrencyCode];
            var copyVisits = new HashSet<Currency>(visited);
            var copyPath = new List<Currency>(currentPath);
            if (!copyVisits.Contains(linkedCurrency))
            {
                BuildPaths(copyPath, linkedCurrency, targetNode, copyVisits, paths);
            }
        }
    }

    public double CalcExchangeAmount(List<Currency> exchangeChain, double amount = 1.0)
    {
        var result = amount;
        for (int i = 0; i < exchangeChain.Count - 1; i++)
        {
            var current = exchangeChain[i];
            var next = exchangeChain[i + 1];
            var exchangeRate = current.ExchangeRateEntries.First(x => x.FromCurrencyCode == current.Code && x.ToCurrencyCode == next.Code);
            result *= exchangeRate.ExchangeRate;
        }

        return result;
    }

}