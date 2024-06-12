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
        var order = StockOrder.Parse(stocksOrders);

        try
        {
            var stockOrderDto = StockOrderToDto(order);
            _stockBrokerOnline.Order(stockOrderDto);
            _notifier.Notify(_formater.CreateMessage(order));

        }
        catch (Exception ex)
        {
            _notifier.Notify(_formater.CreateMessageFail());
        }
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
