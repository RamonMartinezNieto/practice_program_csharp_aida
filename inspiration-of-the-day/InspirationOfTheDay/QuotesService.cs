using System.Collections.Generic;

namespace InspirationOfTheDay;

public interface QuotesService
{
    List<Quote> GetListOfQuotesWith(string word);
}