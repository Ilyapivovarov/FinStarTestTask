namespace FinStarTestTask.Infrastructure.CustomLogger;

public class DbLoggerProvider : ILoggerProvider
{
    private readonly IServiceProvider _serviceScope;

    public DbLoggerProvider(IServiceProvider serviceScope)
    {
        _serviceScope = serviceScope;

    }

    /// <summary>
    /// Creates a new instance of the db logger.
    /// </summary>
    /// <param name="categoryName"></param>
    /// <returns></returns>
    public ILogger CreateLogger(string categoryName)
    {
        return new DbLogger(_serviceScope);
    }

    public void Dispose()
    { }
}