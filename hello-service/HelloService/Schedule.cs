namespace Hello;

public class Schedule
{
    private readonly DateProvider _dateProvider;

    public Schedule(DateProvider dateProvider)
    {
        _dateProvider = dateProvider;
    }

    public bool ItIsMorning()
    {
        var hour = GetCurrentHour();
        return hour >= 6 && hour <= 12;
    }

    public bool ItIsAfternoon()
    {
        var hour = GetCurrentHour();
        return hour > 12 && hour <= 20;
    }

    public bool ItIsNight()
    {
        var hour = GetCurrentHour();
        return hour < 6 || hour > 20;
    }

    private int GetCurrentHour()
    {
        return _dateProvider.GetDate().Hour;
    }
}