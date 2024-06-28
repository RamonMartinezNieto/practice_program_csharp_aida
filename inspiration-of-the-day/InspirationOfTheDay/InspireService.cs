using System.Linq;

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
        var contactData = GetContactData();
        var quote = GetQuote(word);

        if (contactData is not null && quote is not null)
        {
            _quoteSender.Send(quote, contactData);
        }
    }

    private ContactData GetContactData()
    {
        var employees = _employees.GetAll();

        if (employees == null || !employees.Any())
        {
            return null;
        }

        var indexEmployee = _random.GetRandomNumberOf(employees.Count);
        return employees[indexEmployee].GetContactData();
    }

    private Quote GetQuote(string word)
    {
        var quotes = _quotesService.GetListOfQuotesWith(word);

        if (quotes == null || !quotes.Any())
        {
            return null;
        }

        var indexQuote = _random.GetRandomNumberOf(quotes.Count);
        return quotes[indexQuote];
    }
}