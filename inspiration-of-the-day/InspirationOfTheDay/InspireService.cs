namespace InspirationOfTheDay;

public class InspireService
{
    private readonly QuotesService _quotesService;
    private readonly QuoteSender _quoteSender;
    private readonly RandomNumberGenerator _random;
    private readonly Employees _employees;

    public InspireService(QuotesService quotesService, QuoteSender quoteSender, RandomNumberGenerator random, Employees employees)
    {
        _quotesService = quotesService;
        _quoteSender = quoteSender;
        _random = random;
        _employees = employees;
    }

    public void InspireSomeone(string word)
    {
        var employees = _employees.GetAll();
        var indexEmployee = _random.GetRandomNumberOf(employees.Count);

        var quotes = _quotesService.GetListOfQuotesWith(word);
        var indexQuote = _random.GetRandomNumberOf(quotes.Count);

        _quoteSender.Send(quotes[indexQuote], employees[indexEmployee].GetContactData());
    }
}