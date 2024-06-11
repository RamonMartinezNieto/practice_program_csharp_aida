using System;

namespace StockBroker;

public interface TimeProvider
{
    DateTime GetDate();
}