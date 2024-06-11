namespace Hello;

public class HelloService
{
    private readonly Greetings _greetings;
    private readonly Schedule _schedule;

    public HelloService(Notifier notifier, DateProvider dateProvider)
    {
        _greetings = new Greetings(notifier);
        _schedule = new Schedule(dateProvider);

    }

    public void Hello()
    {
        if (_schedule.IsNight())
        {
            _greetings.SayGoodNight();
        }

        if (_schedule.IsAfternoon())
        {
            _greetings.SayGoodAfternoon();
        }

        if (_schedule.IsMorning())
        {
            _greetings.SayGoodMorning();
        }
    }
}