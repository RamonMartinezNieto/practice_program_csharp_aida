namespace StockBroker;

public class StockBrokerService
{
    private readonly Notifier _notifier;
    private readonly StocksOrderSummaryFormatter _formater;

    public StockBrokerService(TimeProvider timeProvider, Notifier notifier)
    {
        _notifier = notifier;
        _formater = new StocksOrderSummaryFormatter(timeProvider);
    }

    public void PlaceOrders(string stocksOrders)
    {
        _notifier.Notify(_formater.CreateMessage());
    }
}