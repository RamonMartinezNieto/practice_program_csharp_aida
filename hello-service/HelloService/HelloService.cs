namespace Hello;

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