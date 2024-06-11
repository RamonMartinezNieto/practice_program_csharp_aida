using NSubstitute;
using NUnit.Framework;

namespace Hello.Tests;

public class HelloServiceTest
{
    private Greetings _greetings;
    private DateProvider _dateProvider;
    private Notifier _notifier;
    private HelloService _helloService;

    [SetUp]
    public void SetUp()
    {
        _notifier = Substitute.For<Notifier>();
        _greetings = new Greetings(_notifier);
        _dateProvider = Substitute.For<DateProvider>();

        _helloService = new(_greetings, _dateProvider);
    }

    [TestCase(8)]
    [TestCase(6)]
    [TestCase(12)]
    public void Say_BuenosDias_At(int hour)
    {
        _dateProvider.GetDate().Returns(DateTimeBuilder.DefaultDateTime().WithHour(hour).Build());

        _helloService.Hello();

        _notifier.Received(1).Notify("Buenos d�as!");
        _notifier.Received(1).Notify(Arg.Any<string>());
    }


    [TestCase(5)]
    [TestCase(23)]
    [TestCase(21)]
    public void Say_GoodNight_At(int hour)
    {
        _dateProvider.GetDate().Returns(DateTimeBuilder.DefaultDateTime().WithHour(hour).Build());

        _helloService.Hello();

        _notifier.Received(1).Notify("Buenas noches!");
        _notifier.Received(1).Notify(Arg.Any<string>());
    }

    [TestCase(13)]
    [TestCase(15)]
    [TestCase(20)]
    public void Say_GoodAfternoon_At(int hour)
    {
        _dateProvider.GetDate().Returns(DateTimeBuilder.DefaultDateTime().WithHour(hour).Build());

        _helloService.Hello();

        _notifier.Received(1).Notify("Buenas tardes!");
        _notifier.Received(1).Notify(Arg.Any<string>());
    }
}