using NSubstitute;
using NUnit.Framework;

namespace StockBroker.Tests
{
    public class StockBrokerServiceTest
    {
        [Test]
        public void EmptyOrder()
        {
            TimeProvider timeProvider = Substitute.For<TimeProvider>();
            Notifier notifier = Substitute.For<Notifier>();

            timeProvider.GetDate().Returns(new DateTime(2019, 08, 15, 14, 45, 0, DateTimeKind.Utc));

            StockBrokerService stockBrokerService = new(timeProvider, notifier);
            stockBrokerService.PlaceOrders("");

            notifier.Received(1).Notify("08/15/2019 14:45 Compra: 0,00 €, Venta: 0,00 €");
        }
    }
}