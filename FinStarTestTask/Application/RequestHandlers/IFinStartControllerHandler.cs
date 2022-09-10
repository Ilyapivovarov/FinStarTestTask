using Microsoft.AspNetCore.Mvc;

namespace FinStarTestTask.Application.RequestHandlers;

public interface IFinStartControllerHandler
{
    public Task<IActionResult> SaveItems(ItemRequest[] items);
    
    public Task<IActionResult> GetItems(string propertyForSort, string sortType);
}