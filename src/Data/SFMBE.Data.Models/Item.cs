namespace SFMBE.Data.Models
{
  using SFMBE.Data.Common.Models;

  public class Item : BaseDeletableModel<int>
  {
    public int Level { get; set; } = 0;

    public ItemType ItemType { get; set; }

    public decimal Price { get; set; }

    public int Stamina { get; set; } = 0;

    public int Strength { get; set; } = 0;

    public int Agility { get; set; } = 0;

    public int Intelligence { get; set; } = 0;

    public int? GearId { get; set; }
    public Gear Gear { get; set; }

    public int? BagId { get; set; }
    public Bag Bag { get; set; }

    public int? VendorId { get; set; }
    public Vendor Vendor { get; set; }
  }
}
