namespace StockBroker.Tests.Builders;

public class StockOrderDtoBuilder
{
    private string _tickerSymbol;
    private int _quantity;
    private decimal _price;
    private char _type;

    private StockOrderDtoBuilder()
    {

    }

    public static StockOrderDtoBuilder BuyStockOrder(string ticker, decimal price, int quantity)
    {
        return new()
        {
            _type = 'B',
            _quantity = quantity,
            _price = price,
            _tickerSymbol = ticker
        };
    }


    public static StockOrderDtoBuilder SellStockOrder(string ticker, decimal price, int quantity)
    {
        return new()
        {
            _type = 'S',
            _quantity = quantity,
            _price = price,
            _tickerSymbol = ticker
        };
    }

    public StockOrderDtoBuilder WithTickerSymbol(string tickerSymbol)
    {
        _tickerSymbol = tickerSymbol;
        return this;
    }

    public StockOrderDtoBuilder WithQuantity(int quantity)
    {
        _quantity = quantity;
        return this;
    }

    public StockOrderDtoBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public StockOrderDto Build()
    {
        return new StockOrderDto()
        {
            TickerSymbol = _tickerSymbol,
            Quantity = _quantity,
            Price = _price,
            Type = _type
        };
    }


}
