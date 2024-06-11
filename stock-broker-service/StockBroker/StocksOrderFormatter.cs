using System.Globalization;

namespace StockBroker;

public class StocksOrderFormatter
{
    private readonly TimeProvider _timeProvider;

    public StocksOrderFormatter(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public string CreateMessage()
    {
        var currTime = _timeProvider.GetDate();
        return $"{currTime.ToString("MM/dd/yyyy HH:mm", new CultureInfo("en-US"))} Compra: 0,00 €, Venta: 0,00 €";
    }
}