using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace InspirationOfTheDay.Tests;

public class InspirationOfTheDayTest
{
    private QuotesService _quotesService;
    private Sender _sender;
    private RandomWrapper _random;
    private InspireService _inspireService;

    [SetUp]
    public void SetUpt()
    {
        _quotesService = Substitute.For<QuotesService>();
        _sender = Substitute.For<Sender>();
        _random = Substitute.For<RandomWrapper>();
        _inspireService = new(_quotesService, _sender, _random);
    }

    [Test]
    public void SendInspirationToEmployee()
    {
        var managerWord = "pato";

        var quotes = StubListOfQuotes();
        _random.SelectOneRandomFrom(quotes).Returns(quotes[0]);

        _inspireService.InspireSomeone(managerWord);

        _sender.Received(1).SendInspiration(
            Arg.Is<string>(x => x.Contains(managerWord)),
            new Employee("Ramon"));

    }

    [Test]
    public void SelectRandomQuoteFromListReceived()
    {
        var quotes = StubListOfQuotes();
        _random.SelectOneRandomFrom(quotes).Returns(quotes[1]);

        _inspireService.InspireSomeone("pato");

        _sender.Received(1).SendInspiration("pato dos", new Employee("Ramon"));
    }

    private List<string> StubListOfQuotes()
    {
        var quotes = new List<string>
        {
            "pato uno",
            "pato dos",
            "pato tres"
        };

        _quotesService.GetListOfQuotesWith("pato").Returns(quotes);
        return quotes;
    }
}