using System;

namespace Hello.Infrastructure;

public class ConsoleNotifier : Notifier
{
    public void Notify(string message)
    {
        Console.WriteLine(message);
    }
}