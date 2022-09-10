using Microsoft.AspNetCore.Mvc;

namespace FinStarTestTask.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class FinStarController : ControllerBase
{
    private readonly IFinStartControllerHandler _finStartControllerHandler;

    public FinStarController(IFinStartControllerHandler finStartControllerHandler)
    {
        _finStartControllerHandler = finStartControllerHandler;
    }

    [HttpPost]
    [Route("items")]
    public async Task<IActionResult> SaveItems(ItemRequest[] itemDtos)
    {
        return await _finStartControllerHandler.SaveItems(itemDtos);
    }
    
    [HttpGet]
    [Route("items")]
    public async Task<IActionResult> GetItems(string propertyForSort, string sortType)
    {
        return await _finStartControllerHandler.GetItems(propertyForSort, sortType);
    }
}