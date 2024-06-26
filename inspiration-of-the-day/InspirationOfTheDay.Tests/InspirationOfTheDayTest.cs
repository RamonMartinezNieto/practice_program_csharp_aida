using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using System;
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
        _random.GetRandomNumberOf(1).Returns(1);

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

    [Test]
    public void NullEmployeesNotCallSend()
    {
        _quotesService.GetListOfQuotesWith("anyword").Returns(new List<Quote>() { new("anyword uno") });
        _employees.GetAll().ReturnsNull();

        var exception = Assert.Throws<Exception>(() =>
            _inspireService.InspireSomeone("anyword")
        );

        Assert.That(exception.Message, Is.EqualTo("There are no employees in the service!"));
        NoSendsReceived();
    }

    [Test]
    public void EmptyEmployeesNotCallSend()
    {
        _quotesService.GetListOfQuotesWith("anyword").Returns(new List<Quote>() { new("anyword uno") });
        _employees.GetAll().Returns(new List<Employee>());

        var exception = Assert.Throws<Exception>(() =>
            _inspireService.InspireSomeone("anyword")
        );

        Assert.That(exception.Message, Is.EqualTo("There are no employees in the service!"));
        NoSendsReceived();
    }

    [Test]
    public void NullQuotesThrowException()
    {
        GivenListOfEmployees();
        _quotesService.GetListOfQuotesWith("eso").ReturnsNull();

        var exception = Assert.Throws<Exception>(() =>
            _inspireService.InspireSomeone("eso")
        );

        Assert.That(exception.Message, Is.EqualTo("Is not possible to retrieve quotes"));

        NoSendsReceived();
    }

    [Test]
    public void EmptyQuotesThrowException()
    {
        GivenListOfEmployees();
        _quotesService.GetListOfQuotesWith("eso").Returns(new List<Quote>());

        var exception = Assert.Throws<Exception>(() =>
            _inspireService.InspireSomeone("eso")
        );

        Assert.That(exception.Message, Is.EqualTo("Is not possible to retrieve quotes"));

        NoSendsReceived();
    }

    private void NoSendsReceived()
    {
        _quoteSender.Received(0).Send(Arg.Any<Quote>(), Arg.Any<ContactData>());
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