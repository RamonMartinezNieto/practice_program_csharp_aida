namespace InspirationOfTheDay;

public interface QuoteSender
{
    void Send(Quote quote, Employee employee);
}

public record Quote
{
    private readonly string _quote;

    public Quote(string quote)
    {
        _quote = quote;
    }
}