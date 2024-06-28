using System;
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

        if (IsDataValid(contactData, quote))
        {
            _quoteSender.Send(quote, contactData);
        }
    }

    private static bool IsDataValid(ContactData contactData, Quote quote)
        => contactData is not null && quote is not null;

    private ContactData GetContactData()
    {
        var employees = _employees.GetAll();

        if (employees?.Any() != true)
        {
            throw new Exception("There are no employees in the service!");
        }

        var indexEmployee = _random.GetRandomNumberOf(employees.Count);
        return employees[indexEmployee].GetContactData();
    }

    private Quote GetQuote(string word)
    {
        var quotes = _quotesService.GetListOfQuotesWith(word);

        if (quotes?.Any() != true)
        {
            throw new Exception("Is not possible to retrieve quotes");
        }

        var indexQuote = _random.GetRandomNumberOf(quotes.Count);
        return quotes[indexQuote];
    }
}