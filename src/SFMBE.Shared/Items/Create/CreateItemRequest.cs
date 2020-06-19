namespace SFMBE.Shared.Items.Create
{
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;

  public class CreateItemRequest : IMapFrom<Character>
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
