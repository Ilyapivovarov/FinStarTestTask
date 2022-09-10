using Microsoft.EntityFrameworkCore;

namespace FinStarTestTask.Infrastructure.Contexts;

public sealed class FinStarTestTaskContext : DbContext, IFinStarTestTaskContext
{
    public FinStarTestTaskContext(DbContextOptions<FinStarTestTaskContext> options)
        : base(options) 
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Item> Items => Set<Item>();
}