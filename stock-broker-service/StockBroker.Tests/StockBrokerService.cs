using System.Globalization;

namespace StockBroker.Tests;

public class StockBrokerService
{
    private readonly TimeProvider _timeProvider;
    private readonly Notifier _notifier;

    public StockBrokerService(TimeProvider timeProvider, Notifier notifier)
    {
        _timeProvider = timeProvider;
        _notifier = notifier;
    }

    public void PlaceOrders(string empty)
    {
        var currTime = _timeProvider.GetDate();
        _notifier.Notify($"{currTime.ToString("MM/dd/yyyy HH:mm", new CultureInfo("en-US"))} Compra: 0,00 €, Venta: 0,00 €");
    }
}