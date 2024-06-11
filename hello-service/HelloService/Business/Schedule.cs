namespace Hello.Business;

public class Schedule
{
    private readonly DateProvider _dateProvider;
    private readonly int _hour;

    public Schedule(DateProvider dateProvider)
    {
        _dateProvider = dateProvider;
        _hour = _dateProvider.GetDate().Hour;
    }

    public bool ItIsMorning()
    {
        var from = _hour > 5;
        var to = _hour < 13;

        return from && to;
    }

    public bool ItIsAfternoon()
    {
        var from = _hour > 12;
        var to = _hour < 21;
        return from && to;
    }

    public bool ItIsNight()
    {
        var from = _hour > 20;
        var to = _hour < 6;
        return from || to;
    }
}