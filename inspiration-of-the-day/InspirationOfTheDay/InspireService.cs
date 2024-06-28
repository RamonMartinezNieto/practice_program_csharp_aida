using System;
using System.Collections.Generic;
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

        _quoteSender.Send(quote, contactData);
    }

    private ContactData GetContactData()
    {
        var employees = _employees.GetAll();

        if (employees?.Any() != true)
        {
            throw new Exception("There are no employees in the service!");
        }

        var indexEmployee = GetNumberOf(employees);
        return employees[indexEmployee].GetContactData();
    }


    private Quote GetQuote(string word)
    {
        var quotes = _quotesService.GetListOfQuotesWith(word);

        if (quotes?.Any() != true)
        {
            throw new Exception("Is not possible to retrieve quotes");
        }

        var indexQuote = GetNumberOf(quotes);
        return quotes[indexQuote];
    }


    private int GetNumberOf<T>(List<T> list)
        => _random.GetRandomNumberOf(MaxNumberOf(list));

    private static int MaxNumberOf<T>(List<T> list)
        => list.Count - 1;

}