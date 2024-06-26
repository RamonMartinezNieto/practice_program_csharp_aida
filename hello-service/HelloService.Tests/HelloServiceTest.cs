using Hello.Business;
using NSubstitute;
using NUnit.Framework;

namespace Hello.Tests;

public class HelloServiceTest
{
    private DateProvider _dateProvider;
    private Notifier _notifier;
    private HelloService _helloService;

    [SetUp]
    public void SetUp()
    {
        _notifier = Substitute.For<Notifier>();
        _dateProvider = Substitute.For<DateProvider>();
    }

    [TestCase(8)]
    [TestCase(6)]
    [TestCase(12)]
    public void Say_BuenosDias_At(int hour)
    {
        GivenDateTimeWithHour(hour);
        _helloService = new(_notifier, _dateProvider);

        CallHello();

        CheckReceivedOneMessageOf("Buenos d�as!");
    }

    [TestCase(5)]
    [TestCase(23)]
    [TestCase(21)]
    public void Say_GoodNight_At(int hour)
    {
        GivenDateTimeWithHour(hour);
        _helloService = new(_notifier, _dateProvider);

        CallHello();

        CheckReceivedOneMessageOf("Buenas noches!");
    }

    [TestCase(13)]
    [TestCase(15)]
    [TestCase(20)]
    public void Say_GoodAfternoon_At(int hour)
    {
        GivenDateTimeWithHour(hour);
        _helloService = new(_notifier, _dateProvider);

        CallHello();

        CheckReceivedOneMessageOf("Buenas tardes!");
    }

    private void GivenDateTimeWithHour(int hour)
    {
        _dateProvider.GetDate().Returns(DateTimeBuilder.DefaultDateTime().WithHour(hour).Build());
    }

    private void CallHello()
    {
        _helloService.Hello();
    }

    private void CheckReceivedOneMessageOf(string message)
    {
        _notifier.Received(1).Notify(message);
        _notifier.Received(1).Notify(Arg.Any<string>());
    }
}