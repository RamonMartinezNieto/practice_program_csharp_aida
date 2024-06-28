using System.Collections.Generic;

namespace InspirationOfTheDay;

public interface RandomWrapper
{
    string SelectOneRandomFrom(List<string> sentences);
}