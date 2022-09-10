namespace FinStarTestTask.Infrastructure.Mapper;

public static class ItemDtoToItemExtensions
{
    public static IEnumerable<Item> ToDbModel(this IEnumerable<ItemRequest> itemDto)
    {
        var itemDtos = itemDto as ItemRequest[] ?? itemDto.ToArray();
        for (var i = 0; i < itemDtos.Length; i++)
        {
            var item = itemDtos[i];
            yield return new Item
            {
                Value = item.Value,
                Code = item.Code,
                Number = i + 1
            };
        }
    }
    
    public static IEnumerable<ItemResponse> ToDto(this IEnumerable<Item> items)
    {
        return items.Select(item => new ItemResponse(item.Number, item.Code, item.Value));
    }
}