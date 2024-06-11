using Hello.Business;

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
        if (_schedule.ItIsNight())
        {
            _greetings.SayGoodNight();
        }

        if (_schedule.ItIsAfternoon())
        {
            _greetings.SayGoodAfternoon();
        }

        if (_schedule.ItIsMorning())
        {
            _greetings.SayGoodMorning();
        }
    }
}