namespace FinStarTestTask.Infrastructure.Repositories;

public sealed class LoggItemRepository : ILoggItemRepository
{
    private readonly IFinStarTestTaskContext _finStarTestTaskContext;

    public LoggItemRepository(IFinStarTestTaskContext finStarTestTaskContext)
    {
        _finStarTestTaskContext = finStarTestTaskContext;
    }
    
    public async Task Save(LoggItem loggItem)
    {
        _finStarTestTaskContext.LogItems.Add(loggItem);

        await _finStarTestTaskContext.SaveChangesAsync();
    }
}