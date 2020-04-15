namespace SFMBE.Shared.Items
{
  using SFMBE.Services.Mapping;
  using SFMBE.Data.Models;

  public class ItemCreateRequestModel : IMapFrom<Character>
  {
    public string ItemType { get; set; }

    public int Level { get; set; }

    public int Stamina { get; set; }

    public int Strength { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }

    public int BagId { get; set; }
  }
}
