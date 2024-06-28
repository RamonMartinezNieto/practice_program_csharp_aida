namespace InspirationOfTheDay;

public class InspireService
{
    private readonly QuotesService _quotesService;
    private readonly Sender _sender;
    private readonly RandomWrapper _random;

    public InspireService(QuotesService quotesService, Sender sender, RandomWrapper random)
    {
        _quotesService = quotesService;
        _sender = sender;
        _random = random;
    }

    public void InspireSomeone(string word)
    {
        _sender.SendInspiration("pato uno", new Employee("Ramon"));
    }
}