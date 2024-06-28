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
        var quotes = _quotesService.GetListOfQuotesWith(word);

        string quote = _random.SelectOneRandomFrom(quotes);

        _sender.SendInspiration(quote, new Employee("Ramon"));
    }
}