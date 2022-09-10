using Microsoft.AspNetCore.Mvc;

namespace FinStarTestTask.Infrastructure.RequestHandlers;

public sealed class FinStartControllerHandler : IFinStartControllerHandler
{
    private readonly ILogger<FinStartControllerHandler> _logger;
    private readonly IItemRepository _itemRepository;

    public FinStartControllerHandler(ILogger<FinStartControllerHandler> logger, IItemRepository itemRepository)
    {
        _logger = logger;
        _itemRepository = itemRepository;
    }

    public async Task<IActionResult> SaveItems(ItemRequest[] items)
    {
        try
        {
            var data = items.OrderBy(x => x.Code).ToDbModel();
            await _itemRepository.ClearTableAndSave(data.ToArray());

            return new OkResult();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }

    public async Task<IActionResult> GetItems(string propertyForSort, string sortTypeName)
    {
        try
        {
            if (!ValidateProperyForSort(propertyForSort))
                throw new ArgumentException(
                    $"Property for sort can only be {string.Join(", ", typeof(Item).GetProperties().Select(x => x.Name))}");
            
            if (!Enum.TryParse<SortType>(sortTypeName, true, out var sortType))
                throw new ArgumentException(
                    $"Sort type name can only be {string.Join(", ", Enum.GetNames(typeof(SortType)))}");

            var items = await _itemRepository.Get(propertyForSort, sortType);
            return new OkObjectResult(items.ToDto());
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }

    private static bool ValidateProperyForSort(string propertyForSort)
    {
        return typeof(Item).GetProperties()
            .Any(x => x.Name.Equals(propertyForSort, StringComparison.OrdinalIgnoreCase));
    }
}