using System;

namespace StockBroker;

public class StockBrokerService
{
    private readonly Notifier _notifier;
    private readonly StockBrokerOnline _stockBrokerOnline;
    private readonly StocksOrderSummaryFormatter _formater;

    public StockBrokerService(
        TimeProvider timeProvider,
        Notifier notifier,
        StockBrokerOnline stockBrokerOnline)
    {
        _notifier = notifier;
        _stockBrokerOnline = stockBrokerOnline;
        _formater = new StocksOrderSummaryFormatter(timeProvider);
    }

    public void PlaceOrders(string stocksOrders)
    {
        string message = string.Empty;

        try
        {
            _stockBrokerOnline.Order(new StockOrderDto());
            if (string.IsNullOrEmpty(stocksOrders))
            {
                message = _formater.CreateMessage();
            }
        }
        catch (Exception ex)
        {
            message = _formater.CreateMessageFail();
        }

        _notifier.Notify(message);
    }
}
