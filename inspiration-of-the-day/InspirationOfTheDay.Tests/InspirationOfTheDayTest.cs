using NSubstitute;
using NUnit.Framework;

namespace InspirationOfTheDay.Tests;

public class InspirationOfTheDayTest
{
    [Test]
    public void SendInspirationToEmployee()
    {
        QuotesService quotesService = Substitute.For<QuotesService>();
        Sender sender = Substitute.For<Sender>();
        RandomWrapper random = Substitute.For<RandomWrapper>();
        InspireService inspireService = new(quotesService, sender, random);

        inspireService.InspireSomeone("pato");

        sender.Received(1).SendInspiration("pato uno", new Employee("Ramon"));
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
