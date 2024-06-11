namespace Hello;

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