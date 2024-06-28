namespace InspirationOfTheDay;

public class InspireService
{
    private readonly QuotesService _quotesService;
    private readonly QuoteSender _quoteSender;
    private readonly RandomNumberGenerator _random;
    private readonly Employees _employees;

    public InspireService(
        QuotesService quotesService,
        QuoteSender quoteSender,
        RandomNumberGenerator random,
        Employees employees)
    {
        _quotesService = quotesService;
        _quoteSender = quoteSender;
        _random = random;
        _employees = employees;
    }

    public void InspireSomeone(string word)
    {
        _quoteSender.Send(GetQuote(word), GetContactData());
    }

    private ContactData GetContactData()
    {
        var employees = _employees.GetAll();
        var indexEmployee = _random.GetRandomNumberOf(employees.Count);
        return employees[indexEmployee].GetContactData();
    }

    private Quote GetQuote(string word)
    {
        var quotes = _quotesService.GetListOfQuotesWith(word);
        var indexQuote = _random.GetRandomNumberOf(quotes.Count);
        return quotes[indexQuote];
    }
}