using System;

namespace Hello;

public class DateTimeProvider : DateProvider
{
    public DateTime GetDate()
    {
        return DateTime.UtcNow;
    }
}
