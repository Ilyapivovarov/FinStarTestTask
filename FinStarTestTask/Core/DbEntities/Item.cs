namespace FinStarTestTask.Core.DbEntities;

public class Item
{
    public long Id { get; set; }

    public int Code { get; set; }

    public string Value { get; set; } = null!;

    public int Number { get; set; }
}