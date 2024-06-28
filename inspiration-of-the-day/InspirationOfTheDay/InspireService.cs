namespace InspirationOfTheDay;

public class InspireService
{
    private readonly QuotesService _quotesService;
    private readonly Sender _sender;
    private readonly RandomNumberGenerator _random;
    private readonly Employees _employees;

    public InspireService(QuotesService quotesService, Sender sender, RandomNumberGenerator random, Employees employees)
    {
        _quotesService = quotesService;
        _sender = sender;
        _random = random;
        _employees = employees;
    }

    public void InspireSomeone(string word)
    {



        // OLD
        //var quotes = _quotesService.GetListOfQuotesWith(word);

        //string quote = _random.SelectOneRandomFrom(quotes);

        //_sender.SendInspiration(quote, new Employee("Ramon"));
    }
}