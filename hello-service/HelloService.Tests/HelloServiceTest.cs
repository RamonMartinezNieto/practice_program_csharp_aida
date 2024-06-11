using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace Hello.Tests;

public class HelloServiceTest
{
    private Notifier _notifier;
    private DateProvider _dateProvider;

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
        _dateProvider.GetDate().Returns(DateTimeBuilder.DefaultDateTime().WithHour(hour).Build());

        HelloService helloService = new(_notifier, _dateProvider);

        helloService.Hello();

        _notifier.Received(1).SayGoodMorning();
    }


    [TestCase(5)]
    public void Say_GoodNight_At(int hour)
    {
        _dateProvider.GetDate().Returns(DateTimeBuilder.DefaultDateTime().WithHour(hour).Build());

        HelloService helloService = new(_notifier, _dateProvider);

        helloService.Hello();

        _notifier.Received(1).SayGoodNight();
    }

}