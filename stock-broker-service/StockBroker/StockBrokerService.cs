using StockBroker.Business;
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

        if (string.IsNullOrEmpty(stocksOrders))
        {
            message = _formater.CreateMessage();
            _notifier.Notify(message);
            return;
        }

        try
        {
            var stockOrder = StockOrder.Parse(stocksOrders);
            var stockOrderDto = StockOrderToDto(stockOrder);

            _stockBrokerOnline.Order(stockOrderDto);
            message = _formater.CreateMessage(stockOrder);
        }
        catch (Exception ex)
        {
            message = _formater.CreateMessageFail();
        }

        _notifier.Notify(message);
    }

    private StockOrderDto StockOrderToDto(StockOrder stockOrder)
    {
        return new StockOrderDto()
        {
            TickerSymbol = stockOrder.TickerSymbol,
            Price = stockOrder.Price,
            Quantity = stockOrder.Quantity,
            Type = GetTypeString(stockOrder)
        };
    }

    private static char GetTypeString(StockOrder stockOrder)
    {
        return stockOrder.Type switch
        {
            OrderType.Buy => 'B',
            OrderType.None => ' ',
            _ => ' ',
        };
    }
}
