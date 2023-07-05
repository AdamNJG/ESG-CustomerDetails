using ESG_Rest_Server_Application.CustomerDetails;
using Microsoft.Extensions.Logging;

namespace ESG_Rest_Server_Test.TestDoubles
{
    public class CustomerDetailsServiceLoggerSpy : ILogger<CustomerDetailsService>
    {
        public List<string> LogEntries { get; private set; }

        public CustomerDetailsServiceLoggerSpy()
        {
            LogEntries = new List<string>();
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            LogEntries.Add(formatter(state, exception));
        }
    }
}
