namespace FinStarTestTask.Application.Repositories;

public interface ILoggItemRepository
{
    Task Save(LoggItem loggItem);
}