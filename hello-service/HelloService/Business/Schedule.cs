using System;

namespace Hello.Business;

public class Schedule
{
    private readonly int _hour;
    private readonly TimeOnly _timeOnly;

    private readonly TimeBetween _morning;
    private readonly TimeBetween _afternoon;
    private readonly TimeBetween _night;

    public Schedule(DateProvider dateProvider)
    {
        _hour = dateProvider.GetDate().Hour;
        _timeOnly = TimeOnly.FromDateTime(dateProvider.GetDate());

        _morning = new(TimeOnlyWith(5), TimeOnlyWith(13));
        _afternoon = new(TimeOnlyWith(12), TimeOnlyWith(21));
        _night = new(TimeOnlyWith(20), TimeOnlyWith(6));
    }

    public bool ItIsMorning()
    {
        return _morning.IsInTime(_timeOnly);
    }

    public bool ItIsAfternoon()
    {
        return _afternoon.IsInTime(_timeOnly);
    }

    public bool ItIsNight()
    {
        //need check in IsInTime cross midgnight
        //return _night.IsInTime(_timeOnly);

        var from = _hour > 20;
        var to = _hour < 6;
        return from || to;
    }

    private static TimeOnly TimeOnlyWith(int hour)
    {
        return new TimeOnly(hour, 0, 0);
    }
}