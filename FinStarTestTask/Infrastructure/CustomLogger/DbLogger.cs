using Microsoft.OpenApi.Extensions;

namespace FinStarTestTask.Infrastructure.CustomLogger;

public sealed class DbLogger : ILogger
{
    private readonly IServiceProvider _serviceProvider;

    public DbLogger(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return new ScopeLog(state?.ToString(), this);
    }

    /// <summary>
    /// Whether to log the entry.
    /// </summary>
    /// <param name="logLevel"></param>
    /// <returns></returns>
    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel != LogLevel.None;
    }
    
    /// <summary>
    /// Used to log the entry.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <param name="logLevel">An instance of <see cref="LogLevel"/>.</param>
    /// <param name="eventId">The event's ID. An instance of <see cref="EventId"/>.</param>
    /// <param name="state">The event's state.</param>
    /// <param name="exception">The event's exception. An instance of <see cref="Exception" /></param>
    /// <param name="formatter">A delegate that formats </param>
    public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
        Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }
        
        using var service = _serviceProvider.CreateScope();
        var loggItemRepository = service.ServiceProvider.GetRequiredService<ILoggItemRepository>();

        await loggItemRepository.Save(new LoggItem()
        {
            Message = formatter(state, exception),
            LogLevel = logLevel.GetDisplayName(),
        });
    }
}