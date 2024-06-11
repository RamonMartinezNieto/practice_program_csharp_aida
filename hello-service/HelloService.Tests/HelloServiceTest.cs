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

    [Test]
    public void Say_BuenosDias_At_8AM()
    {
        _dateProvider.GetDate().Returns(DateTimeBuilder.DefaultDateTime().WithHour(8).Build());

        HelloService helloService = new(_notifier, _dateProvider);

        helloService.Hello();

        _notifier.Received(1).SayGoodMorning();
    }
}

public class DateTimeBuilder
{
    private int _year;
    private int _month;
    private int _day;
    private int _hour;
    private int _minute;
    private int _second;
    private DateTimeKind _kind;

    private DateTimeBuilder()
    {
        _year = 2024;
        _month = 6;
        _day = 11;
        _hour = 0;
        _minute = 0;
        _second = 0;
        _kind = DateTimeKind.Utc;
    }

    public DateTimeBuilder WithHour(int hour)
    {
        _hour = hour;
        return this;
    }

    public static DateTimeBuilder DefaultDateTime()
    {
        return new DateTimeBuilder();
    }

    public DateTime Build()
    {
        return new DateTime(_year, _month, _day, _hour, _minute, _second, _kind);
    }
}