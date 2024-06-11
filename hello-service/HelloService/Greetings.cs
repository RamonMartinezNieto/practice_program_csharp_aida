namespace Hello;

public class Greetings
{
    private const string GoodMorning = "Buenos días!";
    private const string GoodNight = "Buenas noches!";
    private const string GoodAfternoon = "Buenas tardes!";

    private readonly Notifier _notifier;

    public Greetings(Notifier notifier)
    {
        _notifier = notifier;
    }

    public void SayGoodMorning()
    {
        _notifier.Notify(GoodMorning);
    }

    public void SayGoodNight()
    {
        _notifier.Notify(GoodNight);
    }

    public void SayGoodAfternoon()
    {
        _notifier.Notify(GoodAfternoon);
    }
}