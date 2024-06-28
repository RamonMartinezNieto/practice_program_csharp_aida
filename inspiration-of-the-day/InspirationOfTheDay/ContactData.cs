namespace InspirationOfTheDay;

public record ContactData
{
    private readonly string _telephone;

    public ContactData(string telephone)
    {
        _telephone = telephone;
    }

    public override string ToString()
    {
        return $"{nameof(ContactData)}: {nameof(_telephone)}: {_telephone}";
    }

    public virtual bool Equals(ContactData other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _telephone == other._telephone;
    }

    public override int GetHashCode()
    {
        return (_telephone != null ? _telephone.GetHashCode() : 0);
    }
}