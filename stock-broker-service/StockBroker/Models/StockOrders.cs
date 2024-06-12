using System.Collections.Generic;
using System.Linq;

namespace StockBroker.Models;

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

        var allOrders = stocksOrders.Split(',');

        foreach (var currOrder in allOrders)
        {
            orders._orders.Add(StockOrder.Parse(currOrder));
        }
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

    public IEnumerable<string> GetFailedTickerSymbols()
    {
        return FailedOrders.Select(x => x.TickerSymbol);
    }
}