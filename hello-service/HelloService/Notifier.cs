using System;

namespace Hello;

public interface Notifier
{
    void Notify(string message);
}


public class ConsoleNotifier : Notifier
{
    public void Notify(string message)
    {
        Console.WriteLine(message);
    }
}