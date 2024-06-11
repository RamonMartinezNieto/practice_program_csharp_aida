namespace Hello;

public class HelloService
{
    private readonly Greetings _greetings;
    private readonly Schedule _schedule;

    public HelloService(Greetings greetings, Schedule schedule)
    {
        _greetings = greetings;
        _schedule = schedule;

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