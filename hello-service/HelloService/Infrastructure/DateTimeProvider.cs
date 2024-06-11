using System;
using Hello.Business;

namespace Hello.Infrastructure;

public class DateTimeProvider : DateProvider
{
    public DateTime GetDate()
    {
        return DateTime.UtcNow;
    }
}
