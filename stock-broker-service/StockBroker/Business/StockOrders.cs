using System.Collections.Generic;
using System.Linq;

namespace StockBroker.Business;

public class StockOrders
{
    private readonly List<StockOrder> _orders;

    public IEnumerable<StockOrder> AllOrders => _orders;
    public IEnumerable<StockOrder> BuyOrders => _orders.Where(x => x.Type.Equals(OrderType.Buy));

    private StockOrders()
    {
        _orders = new List<StockOrder>();
    }

    public static StockOrders Parse(string stocksOrders)
    {
        StockOrders orders = new();
        orders._orders.Add(StockOrder.Parse(stocksOrders));
        return orders;
    }

    public decimal CalculateTotalBuyPrice()
    {
        return BuyOrders.Sum(order => (order.Price * order.Quantity));
    }
}