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