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
        var currentDate = _dateProvider.GetDate();

        var hour = currentDate.Hour;

        if (hour < 6 || hour > 20)
        {
            _greetings.SayGoodNight();
        }

        if (hour >= 12)
        {
            _greetings.SayGoodAfternoon();
        }

        _greetings.SayGoodMorning();
    }
}