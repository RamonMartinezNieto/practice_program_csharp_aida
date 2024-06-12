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

    public string CreateMessage(StockOrders stockOrder)
    {
        var currTime = _timeProvider.GetDate();
        var priceBuy = stockOrder.CalculateTotalBuyPrice().ToString("0.00", _cultureInfo);

        return $"{currTime.ToString("MM/dd/yyyy HH:mm", _cultureInfo)} Buy: € {priceBuy}, Sell: € 0.00";
    }

    public string CreateMessageFail()
    {
        var currTime = _timeProvider.GetDate();
        return $"{currTime.ToString("MM/dd/yyyy HH:mm", _cultureInfo)} Buy: € 0.00, Sell: € 0.00, Failed: GOOG";
    }
}