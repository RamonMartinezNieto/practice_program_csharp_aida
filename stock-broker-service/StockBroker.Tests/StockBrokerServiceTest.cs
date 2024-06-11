using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

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

        _notifier.Received(1).Notify("08/15/2019 14:45 Compra: 0,00 €, Venta: 0,00 €");
    }
}