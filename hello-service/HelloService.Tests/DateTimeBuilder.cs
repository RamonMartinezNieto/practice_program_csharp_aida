namespace Hello.Tests;

public class DateTimeBuilder
{
    private int _year;
    private int _month;
    private int _day;
    private int _hour;
    private int _minute;
    private int _second;
    private DateTimeKind _kind;

    private DateTimeBuilder()
    {
        _year = 2024;
        _month = 6;
        _day = 11;
        _hour = 0;
        _minute = 0;
        _second = 0;
        _kind = DateTimeKind.Utc;
    }

    public DateTimeBuilder WithHour(int hour)
    {
        _hour = hour;
        return this;
    }

    public static DateTimeBuilder DefaultDateTime()
    {
        return new DateTimeBuilder();
    }

    public DateTime Build()
    {
        return new DateTime(_year, _month, _day, _hour, _minute, _second, _kind);
    }
}