using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace Hello.Tests;

public class HelloServiceTest
{
    [Test]
    public void Say_BuenosDias_At_8AM()
    {
        Notifier notifier = Substitute.For<Notifier>();
        DateProvider dateProvider = Substitute.For<DateProvider>();
        dateProvider.GetDate().Returns(new DateTime(2024, 06, 11, 08, 00, 00, DateTimeKind.Utc));

        HelloService helloService = new(notifier, dateProvider);

        helloService.Hello();

        notifier.Received(1).SayGoodMorning();
    }
}

public class HelloService
{
    private readonly Notifier _notifier;
    private readonly DateProvider _dateProvider;

    public HelloService(Notifier notifier, DateProvider dateProvider)
    {
        _notifier = notifier;
        _dateProvider = dateProvider;
    }

    public void Hello()
    {
        _notifier.SayGoodMorning();
    }
}

public interface DateProvider
{
    DateTime GetDate();
}

public interface Notifier
{
    void SayGoodMorning();
}
