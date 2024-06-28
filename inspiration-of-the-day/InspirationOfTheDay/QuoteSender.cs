namespace InspirationOfTheDay;

public interface QuoteSender
{
    void Send(Quote quote, ContactData contactData);
}