namespace SFMBE.Data.Models
{
  using SFMBE.Data.Common.Models;

  public class Item : BaseDeletableModel<int>
  {
    public int Level { get; set; } = 0;

    public ItemType ItemType { get; set; }

    public decimal Price { get; set; }

    public int Stamina { get; set; }

    public int Strength { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }

    public int? CharacterId { get; set; }
    public Character Character { get; set; }

    public int? VendorId { get; set; }
    public Vendor Vendor { get; set; }

    public bool? IsEquip { get; set; }
  }
}
