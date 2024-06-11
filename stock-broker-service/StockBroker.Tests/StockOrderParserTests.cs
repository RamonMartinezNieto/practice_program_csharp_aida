using FluentAssertions;
using NUnit.Framework;
using System.Globalization;

namespace StockBroker.Tests;

public class StockOrderParserTests
{
    [Test]
    public void ParseOneBuyOrder()
    {
        StockOrderParser parser = new();

        StockOrder order = parser.ParseOrder("GOOG 300 829.08 B");

        order.TickerSymbol.Should().Be("GOOG");
        order.Quantity.Should().Be(300);
        order.Price.Should().Be(829.08m);
        order.Type.Should().Be(OrderType.Buy);
    }
}

public class StockOrder
{
    public string TickerSymbol { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
    public OrderType Type { get; init; }

    public StockOrder(string tickerSymbol, int quantity, decimal price, OrderType type)
    {
        TickerSymbol = tickerSymbol;
        Quantity = quantity;
        Price = price;
        Type = type;
    }
}

public enum OrderType
{
    Buy,
    None
}

public class StockOrderParser
{
    public StockOrder ParseOrder(string order)
    {
        var orderItems = order.Split(" ");
        var tickerSymbol = orderItems[0];
        var quantity = int.Parse(orderItems[1]);
        var price = decimal.Parse(orderItems[2], CultureInfo.InvariantCulture);
        var type = GetType(orderItems[3]);
        return new StockOrder(tickerSymbol, quantity, price, type);
    }


    private static OrderType GetType(string orderItems)
    {
        if (orderItems.Equals("B"))
        {
            return OrderType.Buy;
        }

        return OrderType.None;
    }
}
