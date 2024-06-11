namespace Hello;

public class HelloService
{
    private readonly Greetings _greetings;
    private readonly DateProvider _dateProvider;
    private readonly Schedule _schedule;

    public HelloService(Greetings greetings, DateProvider dateProvider)
    {
        _greetings = greetings;
        _dateProvider = dateProvider;
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

public class Schedule
{
    private readonly DateProvider _dateProvider;

    public Schedule(DateProvider dateProvider)
    {
        _dateProvider = dateProvider;
    }

    public bool IsMorning()
    {
        var hour = GetCurrentHour();
        return hour >= 6 && hour <= 12;
    }

    public bool IsAfternoon()
    {
        var hour = GetCurrentHour();
        return hour > 12 && hour <= 20;
    }

    public bool IsNight()
    {
        var hour = GetCurrentHour();
        return hour < 6 || hour > 20;
    }

    private int GetCurrentHour()
    {
        return _dateProvider.GetDate().Hour;
    }
}