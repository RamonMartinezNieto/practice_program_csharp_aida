namespace InspirationOfTheDay;

public interface Sender
{
    void SendQuote(Quote quote, Employee employee);
}

public record Quote
{
    private readonly string _quote;

    public Quote(string quote)
    {
        _quote = quote;
    }
}