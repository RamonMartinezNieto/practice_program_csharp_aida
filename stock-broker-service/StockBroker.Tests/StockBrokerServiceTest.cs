using NSubstitute;
using NUnit.Framework;

namespace StockBroker.Tests;

public class StockBrokerServiceTest
{
    private TimeProvider _timeProvider;
    private Notifier _notifier;

    private StockBrokerService _stockBrokerService;

    [SetUp]
    public void SetUp()
    {
        _timeProvider = Substitute.For<TimeProvider>();
        _notifier = Substitute.For<Notifier>();

        _stockBrokerService = new(_timeProvider, _notifier);
    }

    [Test]
    public void EmptyOrder()
    {
        _timeProvider.GetDate().Returns(new DateTime(2019, 08, 15, 14, 45, 0, DateTimeKind.Utc));

        _stockBrokerService.PlaceOrders("");

        _notifier.Received(1).Notify("08/15/2019 14:45 Buy: € 0.00, Sell: € 0.00");
    }

    [Test]
    [Ignore("Change last test")]
    public void OrderOneStockFailed()
    {
        _timeProvider.GetDate().Returns(new DateTime(2009, 06, 18, 13, 45, 0, DateTimeKind.Utc));

        _stockBrokerService.PlaceOrders("GOOG 300 829.08 B");

        _notifier.Received(1).Notify("06/18/2009 14:45 Compra: 0,00 €, Venta: 0,00 €, Failed: GOOG");
    }
}