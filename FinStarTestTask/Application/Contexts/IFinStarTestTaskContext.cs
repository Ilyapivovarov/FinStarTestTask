using Microsoft.EntityFrameworkCore;

namespace FinStarTestTask.Application.Contexts;

public interface IFinStarTestTaskContext
{
    DbSet<Item> Items { get; }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}