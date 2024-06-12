using StockBroker.Business;
using System.Globalization;

namespace StockBroker;

public class StocksOrderSummaryFormatter
{
    private readonly TimeProvider _timeProvider;
    private CultureInfo _cultureInfo = new("en-US");

    public StocksOrderSummaryFormatter(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public string CreateMessage(StockOrders stockOrders)
    {
        var currTime = _timeProvider.GetDate();
        var priceBuy = stockOrders.CalculateTotalBuyPrice().ToString("0.00", _cultureInfo);
        var priceSell = stockOrders.CalculateTotalSellPrice().ToString("0.00", _cultureInfo);

        var failed = GenerateFailedMessagePart(stockOrders);

        return $"{currTime.ToString("MM/dd/yyyy HH:mm", _cultureInfo)} Buy: € {priceBuy}, Sell: € {priceSell}{failed}";
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