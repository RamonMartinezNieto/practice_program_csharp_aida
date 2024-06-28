using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace InspirationOfTheDay.Tests;

public class InspirationOfTheDayTest
{
    private QuotesService _quotesService;
    private QuoteSender _quoteSender;
    private RandomNumberGenerator _random;
    private InspireService _inspireService;
    private Employees _employees;

    [SetUp]
    public void SetUpt()
    {
        _quotesService = Substitute.For<QuotesService>();
        _quoteSender = Substitute.For<QuoteSender>();
        _random = Substitute.For<RandomNumberGenerator>();
        _employees = Substitute.For<Employees>();
        _inspireService = new(_quotesService, _quoteSender, _random, _employees);
    }

    [Test]
    public void SendInspirationWithOnlyOneQuoteAndAnEmployee()
    {
        _employees.GetAll().Returns(new List<Employee>() { new("999") });
        _quotesService.GetListOfQuotesWith("pato").Returns(new List<Quote>() { new($"pato uno") });

        _inspireService.InspireSomeone("pato");
        ThenReceivedSend("pato uno", "999");
    }

    [Test]
    public void WithSeveralEmployeesAndOnlyOneQuote()
    {
        GivenListOfEmployees();
        _quotesService.GetListOfQuotesWith("superman").Returns(new List<Quote>() { new("superman uno") });
        _random.GetRandomNumberOf(2).Returns(1);

        _inspireService.InspireSomeone("superman");

        ThenReceivedSend("superman uno", "888");
    }

    [Test]
    public void WithSeveralEmployeesAndSeveralQuotes()
    {
        GivenListOfEmployees();
        _quotesService.GetListOfQuotesWith("superman").Returns(new List<Quote>() { new("superman uno"), new("superman dos") });
        _random.GetRandomNumberOf(Arg.Any<int>()).Returns(1, 1);

        _inspireService.InspireSomeone("superman");

        ThenReceivedSend("superman dos", "888");
    }

    private void ThenReceivedSend(string quote, string telephone)
    {
        _quoteSender.Received(1).Send(new Quote(quote), new ContactData(telephone));
    }

    private void GivenListOfEmployees()
    {
        _employees.GetAll().Returns(new List<Employee>() { new("999"), new("888") });
    }
}