namespace Hello;

public class Greetings
{
    private readonly Notifier _notifier;

    public Greetings(Notifier notifier)
    {
        _notifier = notifier;
    }

    public void SayGoodMorning()
    {
        _notifier.Notify("Buenos días!");
    }

    public void SayGoodNight()
    {
        _notifier.Notify("Buenas noches!");
    }

    public void SayGoodAfternoon()
    {
        _notifier.Notify("Buenas tardes!");
    }
}