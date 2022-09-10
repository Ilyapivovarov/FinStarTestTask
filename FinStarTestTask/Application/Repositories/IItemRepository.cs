namespace FinStarTestTask.Application.Repositories;

public interface IItemRepository
{
    public Task ClearTableAndSave(Item[] items);

    public Task<Item[]> Get(string propertyForSort, SortType sortType);
}