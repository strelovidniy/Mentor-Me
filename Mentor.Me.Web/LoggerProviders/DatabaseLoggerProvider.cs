using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Infrastructure;

namespace Mentor.Me.Web.LoggerProviders
{
    public class DatabaseLoggerProvider : ILoggerProvider
    {
        private IRepository<Log> _logRepository;

        public DatabaseLoggerProvider(IRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(categoryName, _logRepository);
        }

        public void Dispose()
        {
        }

        public class Logger : ILogger
        {
            private readonly string _categoryName;
            private readonly IRepository<Log> _logRepository;

            public Logger(string categoryName, IRepository<Log> logRepository)
            {
                _logRepository = logRepository;
                _categoryName = categoryName;
            }

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) => 
                RecordMsg(logLevel, eventId, state, exception, formatter);

            private void RecordMsg<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                _logRepository.AddAsync(new Log
                {
                    LogLevel = logLevel.ToString(),
                    CategoryName = _categoryName,
                    Message = formatter(state, exception),
                    Timestamp = DateTime.Now
                });
            }

            public IDisposable BeginScope<TState>(TState state) => 
                new NoopDisposable();

            private class NoopDisposable : IDisposable
            {
                public void Dispose()
                {
                }
            }
        }
    }
}
