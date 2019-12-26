using Microsoft.Extensions.Logging;
using SimpleBackOfficeAdmin.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBackOfficeAdmin.Test
{
    class LoggerTest : ILogger<DeptManager>
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }
    }
}
