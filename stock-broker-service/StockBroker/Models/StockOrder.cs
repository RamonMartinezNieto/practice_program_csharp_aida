﻿using System.Globalization;

namespace StockBroker.Models;

public class StockOrder
{
    public bool IsFaulted { get; private set; }
    public string TickerSymbol { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
    public OrderType Type { get; init; }

    private StockOrder(string tickerSymbol, int quantity, decimal price, OrderType type)
    {
        TickerSymbol = tickerSymbol;
        Quantity = quantity;
        Price = price;
        Type = type;
    }

    private StockOrder()
    {
        TickerSymbol = string.Empty;
        Quantity = 0;
        Price = 0.00M;
        Type = OrderType.None;
    }

    public static StockOrder Parse(string order)
    {
        if (string.IsNullOrEmpty(order))
        {
            return new StockOrder();
        }

        var orderItems = order.Split(" ");
        var tickerSymbol = orderItems[0];
        var quantity = int.Parse(orderItems[1]);
        var price = decimal.Parse(orderItems[2], CultureInfo.InvariantCulture);
        var type = GetType(orderItems[3]);
        return new StockOrder(tickerSymbol, quantity, price, type);
    }

    private static OrderType GetType(string orderItems)
    {
        return orderItems switch
        {
            "B" => OrderType.Buy,
            "S" => OrderType.Sell,
            _ => OrderType.None,
        };
    }

    public decimal CalculateStockOrderPrice()
    {
        return Quantity * Price;
    }

    public void SetFail()
    {
        IsFaulted = true;
    }
}