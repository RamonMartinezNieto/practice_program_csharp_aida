using System.Collections.Generic;
using System.Linq;

namespace StockBroker.Business;

public class StockOrders
{
    private readonly List<StockOrder> _orders;

    public IEnumerable<StockOrder> AllOrders => _orders;
    private IEnumerable<StockOrder> BuyOrders => _orders.Where(x => x.Type.Equals(OrderType.Buy) && !x.IsFaulted);
    private IEnumerable<StockOrder> SellOrders => _orders.Where(x => x.Type.Equals(OrderType.Sell) && !x.IsFaulted);
    private IEnumerable<StockOrder> FailedOrders => _orders.Where(x => x.IsFaulted);


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
        return BuyOrders.Sum(order => order.CalculateStockOrderPrice());
    }

    public decimal CalculateTotalSellPrice()
    {
        return SellOrders.Sum(order => order.CalculateStockOrderPrice());
    }

    public bool ThereIsAnyFaultedOrder()
    {
        return FailedOrders.Any();
    }
}