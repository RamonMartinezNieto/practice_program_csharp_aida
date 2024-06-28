namespace InspirationOfTheDay;

public record Quote
{
    private readonly string _quote;

    public Quote(string quote)
    {
        _quote = quote;
    }

    public override string ToString()
    {
        return $"{nameof(Quote)}: {nameof(_quote)}: {_quote}";
    }

    public virtual bool Equals(Quote other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _quote == other._quote;
    }

    public override int GetHashCode()
    {
        return (_quote != null ? _quote.GetHashCode() : 0);
    }
}