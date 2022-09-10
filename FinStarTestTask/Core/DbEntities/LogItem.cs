namespace FinStarTestTask.Core.DbEntities;

public class LoggItem 
{
    public long Id { get; set; }

    public string LogLevel { get; set; } = null!;

    public string Message { get; set; } = null!;
}