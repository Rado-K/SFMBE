namespace SFMBE.Shared.Items.Queries
{
  using SFMBE.Data.Models;

  public class GetItemQueryResponse
  {
    public int Id { get; set; }

    public string ItemType { get; set; } = "Empty";

    public int Level { get; set; }

    public int Stamina { get; set; }

    public int Strength { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }

    public static GetItemQueryResponse FromItem(Item item)
    {
      return new GetItemQueryResponse
      {
        Id = item.Id,
        ItemType = item.ItemType.ToString(),
        Level = item.Level,
        Stamina = item.Stamina,
        Strength = item.Strength,
        Agility = item.Agility,
        Intelligence = item.Intelligence
      };
    }
  }
}
