using StockBroker.Models;

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
        var orders = StockOrders.Parse(stocksOrders);

        foreach (var order in orders.AllOrders)
        {
            var stockOrderDto = StockOrderToDto(order);

            try
            {
                _stockBrokerOnline.Order(stockOrderDto);
            }
            catch
            {
                order.SetFail();
            }
        }

        _notifier.Notify(_formater.CreateMessage(orders));
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
            OrderType.Sell => 'S',
            _ => ' ',
        };
    }
}