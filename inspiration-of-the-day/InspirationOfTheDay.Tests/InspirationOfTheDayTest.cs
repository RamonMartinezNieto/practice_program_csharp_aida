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

public interface QuotesService
{
}

public interface Sender
{
    void SendInspiration(string quote, Employee employee);
}

public interface RandomWrapper
{
}

public class InspireService
{
    private readonly QuotesService _quotesService;
    private readonly Sender _sender;
    private readonly RandomWrapper _random;

    public InspireService(QuotesService quotesService, Sender sender, RandomWrapper random)
    {
        _quotesService = quotesService;
        _sender = sender;
        _random = random;
    }

    public void InspireSomeone(string word)
    {
        _sender.SendInspiration("pato uno", new Employee("Ramon"));
    }
}

public record class Employee(string Name)
{
    public string Name { get; init; }
}

public class Employees
{
    private readonly RandomWrapper _random;

    public Employees(RandomWrapper random)
    {
        _random = random;
    }
}
