namespace FinStarTestTask.Infrastructure.CustomLogger;

public sealed class ScopeLog : IDisposable
{
    private readonly string? _state;
    private readonly ILogger _logger;

    public ScopeLog(string? state, ILogger logger)
    {
        _state = state;
        _logger = logger;
        logger.LogTrace($"Enter in {state}");
    }

    public void Dispose()
    {
        _logger.LogTrace($"Exit from {_state}");
    }
}