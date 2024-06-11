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
        var from = _hour >= 6;
        var to = _hour <= 12;

        return from && to;
    }

    public bool ItIsAfternoon()
    {
        return _hour > 12 && _hour <= 20;
    }

    public bool ItIsNight()
    {
        return _hour < 6 || _hour > 20;
    }

}