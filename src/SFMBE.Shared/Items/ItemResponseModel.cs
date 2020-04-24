namespace SFMBE.Shared.Items
{
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;

  public class ItemResponseModel : IMapFrom<Item>
  {
    public string ItemType { get; set; } = "Empty";

    public int Level { get; set; }

    public int Stamina { get; set; }

    public int Strength { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }
  }
}
