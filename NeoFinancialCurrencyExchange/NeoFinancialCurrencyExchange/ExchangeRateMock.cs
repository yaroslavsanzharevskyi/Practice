namespace NeoFinancialCurrencyExchange;

public class Currency
{
    public string Code { get; set; }
    public string Name { get; set; }
    public List<ExchangeRateEntry> ExchangeRateEntries { get; set; }

    public override string ToString()
    {
        return $"{Code} - {Name}";
    }
}

public class ExchangeRateEntry
{
    public double ExchangeRate { get; set; }
    public string FromCurrencyCode { get; set; }
    public string FromCurrencyName { get; set; }
    public string ToCurrencyCode { get; set; }
    public string ToCurrencyName { get; set; }
}

public static class ExchangeRateMock
{
    public static ExchangeRateEntry[] Rates =
    {
        new ExchangeRateEntry()
        {
            ExchangeRate = 6.1678640621357275,
            FromCurrencyCode = "CAD",
            FromCurrencyName = "Canada Dollar",
            ToCurrencyCode = "HKD",
            ToCurrencyName = "Hong Kong Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.795394531464706,
            FromCurrencyCode = "CAD",
            FromCurrencyName = "Canada Dollar",
            ToCurrencyCode = "USD",
            ToCurrencyName = "USA Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.5729840732989149,
            FromCurrencyCode = "USD",
            FromCurrencyName = "USA Dollar",
            ToCurrencyCode = "HKD",
            ToCurrencyName = "Hong Kong Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 4.1477528750967405,
            FromCurrencyCode = "CAD",
            FromCurrencyName = "Canada Dollar",
            ToCurrencyCode = "BRL",
            ToCurrencyName = "Brazil Real"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.6718876453397931,
            FromCurrencyCode = "CAD",
            FromCurrencyName = "Canada Dollar",
            ToCurrencyCode = "EUR",
            ToCurrencyName = "Euro"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 6.456756485225581,
            FromCurrencyCode = "HKD",
            FromCurrencyName = "Hong Kong Dollar",
            ToCurrencyCode = "PHP",
            ToCurrencyName = "Philippines Peso"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 9.538238762941116,
            FromCurrencyCode = "HKD",
            FromCurrencyName = "Hong Kong Dollar",
            ToCurrencyCode = "INR",
            ToCurrencyName = "India Rupee"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 2925.907487750517,
            FromCurrencyCode = "HKD",
            FromCurrencyName = "Hong Kong Dollar",
            ToCurrencyCode = "VND",
            ToCurrencyName = "Vietnam Dong"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 23.696499403223935,
            FromCurrencyCode = "PHP",
            FromCurrencyName = "Philippines Peso",
            ToCurrencyCode = "KRW",
            ToCurrencyName = "South Korea Won"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.0011095847836021348,
            FromCurrencyCode = "KRW",
            FromCurrencyName = "South Korea Won",
            ToCurrencyCode = "SGD",
            ToCurrencyName = "Singapore Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 24.589091893259113,
            FromCurrencyCode = "SGD",
            FromCurrencyName = "Singapore Dollar",
            ToCurrencyCode = "THB",
            ToCurrencyName = "Thailand Baht"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 110.43986068410896,
            FromCurrencyCode = "USD",
            FromCurrencyName = "USA Dollar",
            ToCurrencyCode = "JPY",
            ToCurrencyName = "Japan Yen"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 19.979034773984594,
            FromCurrencyCode = "USD",
            FromCurrencyName = "USA Dollar",
            ToCurrencyCode = "MXN",
            ToCurrencyName = "Mexico Peso"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 3.7836804153970656,
            FromCurrencyCode = "USD",
            FromCurrencyName = "USA Dollar",
            ToCurrencyCode = "SAR",
            ToCurrencyName = "Saudi Arabia Riyal"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 11.39084470207304,
            FromCurrencyCode = "SAR",
            FromCurrencyName = "Saudi Arabia Riyal",
            ToCurrencyCode = "UYU",
            ToCurrencyName = "Uruguay Peso"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 45.68186587050076,
            FromCurrencyCode = "SAR",
            FromCurrencyName = "Saudi Arabia Riyal",
            ToCurrencyCode = "LRD",
            ToCurrencyName = "Liberia Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 118.77243470723415,
            FromCurrencyCode = "SAR",
            FromCurrencyName = "Saudi Arabia Riyal",
            ToCurrencyCode = "SDG",
            ToCurrencyName = "Sudan Pound"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.801521122224709,
            FromCurrencyCode = "LRD",
            FromCurrencyName = "Liberia Dollar",
            ToCurrencyCode = "DZD",
            ToCurrencyName = "Algeria Dinar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 237.2867837561407,
            FromCurrencyCode = "GBP",
            FromCurrencyName = "Great Britain Pound",
            ToCurrencyCode = "LRD",
            ToCurrencyName = "Liberia Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 2109.3756253001916,
            FromCurrencyCode = "GBP",
            FromCurrencyName = "Great Britain Pound",
            ToCurrencyCode = "LBP",
            ToCurrencyName = "Lebanon Pound"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 12.03185608695095,
            FromCurrencyCode = "GBP",
            FromCurrencyName = "Great Britain Pound",
            ToCurrencyCode = "NOK",
            ToCurrencyName = "Norway Kroner"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 1.0049486471014506,
            FromCurrencyCode = "NOK",
            FromCurrencyName = "Norway Kroner",
            ToCurrencyCode = "SEK",
            ToCurrencyName = "Sweden Krona"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.9860888359821617,
            FromCurrencyCode = "SEK",
            FromCurrencyName = "Sweden Krona",
            ToCurrencyCode = "TRY",
            ToCurrencyName = "Turkish New Lira"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.11095253049123384,
            FromCurrencyCode = "SEK",
            FromCurrencyName = "Sweden Krona",
            ToCurrencyCode = "CHF",
            ToCurrencyName = "Switzerland Franc"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 1.304113394748974,
            FromCurrencyCode = "BRL",
            FromCurrencyName = "Brazil Real",
            ToCurrencyCode = "TTD",
            ToCurrencyName = "Trinidad/Tobago Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 8.233949915639602,
            FromCurrencyCode = "BRL",
            FromCurrencyName = "Brazil Real",
            ToCurrencyCode = "UYU",
            ToCurrencyName = "Uruguay Peso"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.06523558820960117,
            FromCurrencyCode = "UYU",
            FromCurrencyName = "Uruguay Peso",
            ToCurrencyCode = "TND",
            ToCurrencyName = "Tunisia Dinar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 18.93467319292391,
            FromCurrencyCode = "BRL",
            FromCurrencyName = "Brazil Real",
            ToCurrencyCode = "ARS",
            ToCurrencyName = "Argentina Peso"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 1.6649570482271538,
            FromCurrencyCode = "EUR",
            FromCurrencyName = "Euro",
            ToCurrencyCode = "NZD",
            ToCurrencyName = "New Zealand Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 1.6005297369790499,
            FromCurrencyCode = "EUR",
            FromCurrencyName = "Euro",
            ToCurrencyCode = "AUD",
            ToCurrencyName = "Australia Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 2.3977683218479253,
            FromCurrencyCode = "EUR",
            FromCurrencyName = "Euro",
            ToCurrencyCode = "BZD",
            ToCurrencyName = "Belize Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.4126967430879673,
            FromCurrencyCode = "BBD",
            FromCurrencyName = "Barbados Dollar",
            ToCurrencyCode = "KYD",
            ToCurrencyName = "Cayman Islands Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 6.49793438604918,
            FromCurrencyCode = "USD",
            FromCurrencyName = "USA Dollar",
            ToCurrencyCode = "CNY",
            ToCurrencyName = "China Yuan/Renminbi"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 1.2158208117460738,
            FromCurrencyCode = "CNY",
            FromCurrencyName = "China Yuan/Renminbi",
            ToCurrencyCode = "HKD",
            ToCurrencyName = "Hong Kong Dollar"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.8518924732295999,
            FromCurrencyCode = "EUR",
            FromCurrencyName = "Euro",
            ToCurrencyCode = "GBP",
            ToCurrencyName = "Great Britain Pound"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.000018013287800948853,
            FromCurrencyCode = "CAD",
            FromCurrencyName = "Canada Dollar",
            ToCurrencyCode = "BTC",
            ToCurrencyName = "Bitcoin"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 14.281156968242023,
            FromCurrencyCode = "BTC",
            FromCurrencyName = "Bitcoin",
            ToCurrencyCode = "ETH",
            ToCurrencyName = "Ethereum"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 4976832.072146286,
            FromCurrencyCode = "BTC",
            FromCurrencyName = "Bitcoin",
            ToCurrencyCode = "BAN",
            ToCurrencyName = "Banano"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 8446.388481236021,
            FromCurrencyCode = "BTC",
            FromCurrencyName = "Bitcoin",
            ToCurrencyCode = "NANO",
            ToCurrencyName = "Nano"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 2.4234261903114196,
            FromCurrencyCode = "NANO",
            FromCurrencyName = "Nano",
            ToCurrencyCode = "ADA",
            ToCurrencyName = "Cardano"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 24.177268419618176,
            FromCurrencyCode = "NANO",
            FromCurrencyName = "Nano",
            ToCurrencyCode = "DOGE",
            ToCurrencyName = "Dogecoin"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.013346747465089119,
            FromCurrencyCode = "ADA",
            FromCurrencyName = "Cardano",
            ToCurrencyCode = "LTC",
            ToCurrencyName = "Litecoin"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 1.1603374424956616,
            FromCurrencyCode = "ADA",
            FromCurrencyName = "Cardano",
            ToCurrencyCode = "ALGO",
            ToCurrencyName = "Algorand"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 0.0038183107239621495,
            FromCurrencyCode = "ALGO",
            FromCurrencyName = "Alogorand",
            ToCurrencyCode = "BCH",
            ToCurrencyName = "BitcoinCash"
        },
        new ExchangeRateEntry()
        {
            ExchangeRate = 77.44036015021159,
            FromCurrencyCode = "BTC",
            FromCurrencyName = "Bitcoin",
            ToCurrencyCode = "BCH",
            ToCurrencyName = "BitcoinCash"
        }
    };
}