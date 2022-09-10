using FinStarTestTask.Infrastructure.Contexts;
using FinStarTestTask.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinStarTestTask.Infrastructure;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Register context 

        services.AddDbContext<FinStarTestTaskContext>(builder
            => builder.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddScoped<IFinStarTestTaskContext, FinStarTestTaskContext>();
        
        #endregion

        #region Register handlers

        services.AddTransient<IFinStartControllerHandler, FinStartControllerHandler>();

        #endregion

        #region Register repositories

        services.AddTransient<IItemRepository, ItemRepository>();

        #endregion
    }
}