using StockBroker.Business;
using System.Globalization;
using System.Linq;

namespace StockBroker;

public class StocksOrderSummaryFormatter
{
    private readonly TimeProvider _timeProvider;
    private CultureInfo _cultureInfo = new("en-US");

    public StocksOrderSummaryFormatter(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public string CreateMessage(StockOrders stockOrder)
    {
        var currTime = _timeProvider.GetDate();
        var priceBuy = stockOrder.CalculateTotalBuyPrice().ToString("0.00", _cultureInfo);
        var priceSell = stockOrder.CalculateTotalSellPrice().ToString("0.00", _cultureInfo);

        var failedOrders = stockOrder.FailedOrders;
        string failed = string.Empty;

        if (failedOrders.Any())
        {
            failed = $", Failed: {string.Join("", failedOrders.Select(x => x.TickerSymbol))}";
        }

        return $"{currTime.ToString("MM/dd/yyyy HH:mm", _cultureInfo)} Buy: € {priceBuy}, Sell: € {priceSell}{failed}";
    }
}