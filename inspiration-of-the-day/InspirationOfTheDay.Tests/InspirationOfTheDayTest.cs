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
        _quotesService.GetListOfQuotesWith("pato").Returns(new List<Quote>() { new("pato uno") });

        _inspireService.InspireSomeone("pato");

        _quoteSender.Received(1).Send(new Quote("pato uno"), new ContactData("999"));
    }

    [Test]
    public void WithSeveralEmployeesAndOnlyOneQuote()
    {
        _employees.GetAll().Returns(new List<Employee>() { new("999"), new("888") });
        _random.GetRandomNumberOf(2).Returns(1);
        _quotesService.GetListOfQuotesWith("superman").Returns(new List<Quote>() { new("superman uno") });

        _inspireService.InspireSomeone("superman");

        _quoteSender.Received(1).Send(new Quote("superman uno"), new ContactData("888"));
    }

    [Test]
    public void WithSeveralEmployeesAndSeveralQuotes()
    {
        _employees.GetAll().Returns(new List<Employee>() { new("999"), new("888") });
        _quotesService.GetListOfQuotesWith("superman").Returns(new List<Quote>() { new("superman uno"), new("superman dos") });
        _random.GetRandomNumberOf(Arg.Any<int>()).Returns(1, 1);

        _inspireService.InspireSomeone("superman");

        _quoteSender.Received(1).Send(new Quote("superman dos"), new ContactData("888"));
    }
}