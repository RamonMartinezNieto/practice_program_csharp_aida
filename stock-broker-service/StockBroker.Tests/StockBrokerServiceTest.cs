using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using System.Globalization;

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

    public class StockBrokerService
    {
        private readonly TimeProvider _timeProvider;
        private readonly Notifier _notifier;

        public StockBrokerService(TimeProvider timeProvider, Notifier notifier)
        {
            _timeProvider = timeProvider;
            _notifier = notifier;
        }

        public void PlaceOrders(string empty)
        {
            var currTime = _timeProvider.GetDate();
            _notifier.Notify($"{currTime.ToString("MM/dd/yyyy HH:mm", new CultureInfo("en-US"))} Compra: 0,00 €, Venta: 0,00 €");
        }
    }

    public interface Notifier
    {
        void Notify(string message);
    }

    public interface TimeProvider
    {
        DateTime GetDate();
    }
}