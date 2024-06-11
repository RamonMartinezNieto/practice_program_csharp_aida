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
        var hour = GetCurrentHour();

        if (_schedule.IsNight(hour))
        {
            _greetings.SayGoodNight();
        }

        if (_schedule.IsAfternoon(hour))
        {
            _greetings.SayGoodAfternoon();
        }

        if (_schedule.IsMorning(hour))
        {
            _greetings.SayGoodMorning();
        }
    }

    private int GetCurrentHour()
    {
        return _dateProvider.GetDate().Hour;
    }
}

public class Schedule
{
    private readonly DateProvider _dateProvider;

    public Schedule(DateProvider dateProvider)
    {
        _dateProvider = dateProvider;
    }

    public bool IsMorning(int hour)
    {
        return hour >= 6 && hour <= 12;
    }

    public bool IsAfternoon(int hour)
    {
        return hour > 12 && hour <= 20;
    }

    public bool IsNight(int hour)
    {
        return hour < 6 || hour > 20;
    }
}