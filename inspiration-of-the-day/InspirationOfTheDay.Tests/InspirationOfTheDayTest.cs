using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace InspirationOfTheDay.Tests;

public class InspirationOfTheDayTest
{
    private QuotesService _quotesService;
    private Sender _sender;
    private RandomNumberGenerator _random;
    private InspireService _inspireService;
    private Employees _employees;

    [SetUp]
    public void SetUpt()
    {
        _quotesService = Substitute.For<QuotesService>();
        _sender = Substitute.For<Sender>();
        _random = Substitute.For<RandomNumberGenerator>();
        _employees = Substitute.For<Employees>();
        _inspireService = new(_quotesService, _sender, _random, _employees);
    }


    //[Test]
    //public void SendInspirationToEmployee()
    //{
    //    var managerWord = "pato";
    //    StubSelectRandomQuote(managerWord, 0);

    //    _inspireService.InspireSomeone(managerWord);

    //    CheckSendInspiration($"{managerWord} uno", new Employee("Ramon"));
    //}


    //[Test]
    //public void SelectRandomQuoteFromListReceived()
    //{
    //    var managerWord = "superman";
    //    StubSelectRandomQuote(managerWord, 1);

    //    _inspireService.InspireSomeone(managerWord);

    //    CheckSendInspiration($"{managerWord} dos", new Employee("Ramon"));
    //}

    private void CheckSendInspiration(string inspiration, Employee employee)
    {
        _sender.Received(1).SendInspiration(Arg.Any<string>(), Arg.Any<Employee>());
        _sender.Received(1).SendInspiration(inspiration, employee);
    }


    private void StubSelectRandomQuote(string word, int index)
    {
        var quotes = StubListOfQuotes(word);
        _random.SelectOneRandomFrom(quotes).Returns(quotes[index]);
    }

    private List<string> StubListOfQuotes(string managerWord)
    {
        var quotes = new List<string>
        {
            $"{managerWord} uno",
            $"{managerWord} dos",
            $"{managerWord} tres"
        };

        _quotesService.GetListOfQuotesWith(managerWord).Returns(quotes);
        return quotes;
    }
}