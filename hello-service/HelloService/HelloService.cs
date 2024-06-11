namespace Hello;

public class HelloService
{
    private readonly Greetings _greetings;
    private readonly DateProvider _dateProvider;

    public HelloService(Greetings greetings, DateProvider dateProvider)
    {
        _greetings = greetings;
        _dateProvider = dateProvider;
    }

    public void Hello()
    {
        var hour = GetCurrentHour();

        if (IsNight(hour))
        {
            _greetings.SayGoodNight();
            return;
        }

        if (IsAfternoon(hour))
        {
            _greetings.SayGoodAfternoon();
            return;
        }

        if (IsMoorning(hour))
        {
            _greetings.SayGoodMorning();
        }
    }

    private bool IsMoorning(int hour)
    {
        return hour >= 6 || hour <= 12;
    }

    private static bool IsAfternoon(int hour)
    {
        return hour > 12;
    }

    private static bool IsNight(int hour)
    {
        return hour < 6 || hour > 20;
    }

    private int GetCurrentHour()
    {
        return _dateProvider.GetDate().Hour;
    }
}