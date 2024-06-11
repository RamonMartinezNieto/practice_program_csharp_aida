using System.Globalization;

namespace StockBroker;

public class StockBrokerService
{
    private readonly Notifier _notifier;
    private readonly StocksOrderFormatter _formater;

    public StockBrokerService(TimeProvider timeProvider, Notifier notifier)
    {
        _notifier = notifier;
        _formater = new StocksOrderFormatter(timeProvider);
    }

    public void PlaceOrders(string stocksOrders)
    {
        _notifier.Notify(_formater.CreateMessage());
    }
}

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
        var message = $"{currTime.ToString("MM/dd/yyyy HH:mm", new CultureInfo("en-US"))} Compra: 0,00 €, Venta: 0,00 €";
        return message;
    }
}