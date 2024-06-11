using System;

namespace Hello.Business;

public class TimeBetween
{
    private readonly TimeOnly _from;
    private readonly TimeOnly _to;

    public TimeBetween(TimeOnly from, TimeOnly to)
    {
        _from = from;
        _to = to;
    }

    public bool IsInTime(TimeOnly time)
    {
        return time.CompareTo(_from) > 0 && time.CompareTo(_to) < 0;
    }
}