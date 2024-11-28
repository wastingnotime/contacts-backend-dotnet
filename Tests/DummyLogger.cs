using System.Diagnostics;
using WastingNoTime.Contacts.Controllers;

namespace WastingNoTime.Contacts.Tests;

public class DummyLogger : ILogger<ContactsController>
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true; 
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        Debug.WriteLine(formatter(state, exception));
    }
}