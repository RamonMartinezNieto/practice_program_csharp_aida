using NSubstitute;
using NUnit.Framework;
using static StockBroker.Tests.DateTimeBuilder;

namespace StockBroker.Tests;

public class StockBrokerServiceTest
{
    private TimeProvider _timeProvider;
    private Notifier _notifier;

    private StockBrokerService _stockBrokerService;
    private StockBrokerOnline _stockBrokerOnline;

    [SetUp]
    public void SetUp()
    {
        _timeProvider = Substitute.For<TimeProvider>();
        _notifier = Substitute.For<Notifier>();
        _stockBrokerOnline = Substitute.For<StockBrokerOnline>();

        _stockBrokerService = new(_timeProvider, _notifier, _stockBrokerOnline);
    }

    [Test]
    public void EmptyOrder()
    {
        _timeProvider.GetDate().Returns(CreateDateTime()
            .WithDate(2019, 08, 15)
            .WithTime(14, 45).Build());

        _stockBrokerService.PlaceOrders("");

        _notifier.Received(1).Notify("08/15/2019 14:45 Buy: � 0.00, Sell: � 0.00");
    }

    [Test]
    public void OrderOneStockFailed()
    {
        _timeProvider.GetDate().Returns(CreateDateTime()
            .WithDate(2009, 06, 18)
            .WithTime(13, 45).Build());

        _stockBrokerOnline
            .When(x => x.Order(Arg.Any<StockOrderDto>()))
            .Do(x => { throw new Exception("Order failed"); });


        _stockBrokerService.PlaceOrders("GOOG 300 829.08 B");

        _notifier.Received(1).Notify("06/18/2009 13:45 Buy: � 0.00, Sell: � 0.00, Failed: GOOG");
    }

    [Test]
    public void OneOrderBuyStockSuccessfully()
    {
        _timeProvider.GetDate().Returns(CreateDateTime()
            .WithDate(2022, 07, 15)
            .WithTime(23, 59).Build());

        _stockBrokerService.PlaceOrders("GOOG 300 829.08 B");

        _stockBrokerOnline.Received(1).Order(new StockOrderDto()
        {
            TickerSymbol = "GOOG",
            Price = 829.08M,
            Quantity = 300,
            Type = 'B'
        });
        _notifier.Received(1).Notify("07/15/2022 23:59 Buy: � 248724.00, Sell: � 0.00");
    }


    [Test]
    public void OneOrderSellStockSuccessfully()
    {
        _timeProvider.GetDate().Returns(CreateDateTime()
            .WithDate(2022, 07, 15)
            .WithTime(23, 59).Build());

        _stockBrokerService.PlaceOrders("FB 10 30 S");

        _stockBrokerOnline.Received(1).Order(new StockOrderDto()
        {
            TickerSymbol = "FB",
            Price = 30.0M,
            Quantity = 10,
            Type = 'S'
        });
        _notifier.Received(1).Notify("07/15/2022 23:59 Buy: � 0.00, Sell: � 300.00");
    }
}