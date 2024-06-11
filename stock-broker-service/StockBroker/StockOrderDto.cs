namespace StockBroker;

public class StockOrderDto
{
    public string TickerSymbol { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public char Type { get; set; }
}