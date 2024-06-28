using System.Collections.Generic;

namespace InspirationOfTheDay;

public interface QuotesService
{
    List<string> GetListOfQuotesWith(string word);
}