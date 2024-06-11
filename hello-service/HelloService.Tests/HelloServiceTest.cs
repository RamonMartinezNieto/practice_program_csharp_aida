using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace Hello.Tests;

public class HelloServiceTest
{
    private Greetings _greetings;
    private DateProvider _dateProvider;

    [SetUp]
    public void SetUp()
    {
        _greetings = Substitute.For<Greetings>();
        _dateProvider = Substitute.For<DateProvider>();
    }

    [TestCase(8)]
    [TestCase(6)]
    [TestCase(12)]
    public void Say_BuenosDias_At(int hour)
    {
        _dateProvider.GetDate().Returns(DateTimeBuilder.DefaultDateTime().WithHour(hour).Build());

        HelloService helloService = new(_greetings, _dateProvider);

        helloService.Hello();

        _greetings.Received(1).SayGoodMorning();
    }


    [TestCase(5)]
    [TestCase(23)]
    [TestCase(21)]
    public void Say_GoodNight_At(int hour)
    {
        _dateProvider.GetDate().Returns(DateTimeBuilder.DefaultDateTime().WithHour(hour).Build());

        HelloService helloService = new(_greetings, _dateProvider);

        helloService.Hello();

        _greetings.Received(1).SayGoodNight();
    }

    [TestCase(12)]
    public void Say_GoodAfternoon_At(int hour)
    {
        _dateProvider.GetDate().Returns(DateTimeBuilder.DefaultDateTime().WithHour(hour).Build());

        HelloService helloService = new(_greetings, _dateProvider);

        helloService.Hello();

        _greetings.Received(1).SayGoodAfternoon();
    }
}