using FinStarTestTask.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FinStarTestTask.Infrastructure.Repositories;

public sealed class ItemRepository : IItemRepository
{
    private readonly IFinStarTestTaskContext _finStarTestTaskContext;

    public ItemRepository(IFinStarTestTaskContext finStarTestTaskContext)
    {
        _finStarTestTaskContext = finStarTestTaskContext;
    }

    public async Task ClearTableAndSave(Item[] items)
    {
        _finStarTestTaskContext.Items.RemoveRange(_finStarTestTaskContext.Items);
        _finStarTestTaskContext.Items.AddRange(items);

        await _finStarTestTaskContext.SaveChangesAsync();
    }

    public async Task<Item[]> Get(string propertyForSort, SortType sortType)
    {
        return await _finStarTestTaskContext.Items
            .OrderBy(propertyForSort, sortType == SortType.ASC)
            .ToArrayAsync();
    }
}
