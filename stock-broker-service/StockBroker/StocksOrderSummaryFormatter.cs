using StockBroker.Business;
using System.Globalization;

namespace StockBroker;

public class StocksOrderSummaryFormatter
{
    private readonly TimeProvider _timeProvider;

    public StocksOrderSummaryFormatter(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public string CreateMessage()
    {
        var currTime = _timeProvider.GetDate();
        return $"{currTime.ToString("MM/dd/yyyy HH:mm", new CultureInfo("en-US"))} Buy: € 0.00, Sell: € 0.00";
    }

    public string CreateMessage(StockOrder stockOrder)
    {
        var currTime = _timeProvider.GetDate();
        var priceBuy = (stockOrder.Quantity * stockOrder.Price).ToString(new CultureInfo("en-US"));
        return $"{currTime.ToString("MM/dd/yyyy HH:mm", new CultureInfo("en-US"))} Buy: € {priceBuy}, Sell: € 0.00";
    }

    public string CreateMessageFail()
    {
        var currTime = _timeProvider.GetDate();
        return $"{currTime.ToString("MM/dd/yyyy HH:mm", new CultureInfo("en-US"))} Buy: € 0.00, Sell: € 0.00, Failed: GOOG";
    }
}