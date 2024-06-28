using NSubstitute;
using NUnit.Framework;

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
        _inspireService.InspireSomeone("pato");

        _sender.Received(1).SendInspiration("pato uno", new Employee("Ramon"));
    }
}