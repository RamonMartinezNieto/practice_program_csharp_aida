using StockBroker.Models;
using System.Globalization;

namespace StockBroker;

public class StocksOrderSummaryFormatter
{
    private readonly TimeProvider _timeProvider;
    private readonly CultureInfo _cultureInfo = new("en-US");

    public StocksOrderSummaryFormatter(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public string CreateMessage(StockOrders stockOrders)
    {
        var timeFormatted = GetTimeFormatted();
        var priceBuy = DecimalToString(stockOrders.CalculateTotalBuyPrice());
        var priceSell = DecimalToString(stockOrders.CalculateTotalSellPrice());

        var failed = GenerateFailedMessagePart(stockOrders);

        return $"{timeFormatted} Buy: € {priceBuy}, Sell: € {priceSell}{failed}";
    }

    private string GetTimeFormatted()
    {
        var currTime = _timeProvider.GetDate();
        return currTime.ToString("MM/dd/yyyy HH:mm", _cultureInfo);
    }

    private string DecimalToString(decimal price)
    {
        return price.ToString("0.00", _cultureInfo);
    }

    private string GenerateFailedMessagePart(StockOrders stockOrders)
    {
        if (stockOrders.ThereIsAnyFaultedOrder())
        {
            return $", Failed: {string.Join(", ", stockOrders.GetFailedTickerSymbols())}";
        }

        return string.Empty;
    }
}