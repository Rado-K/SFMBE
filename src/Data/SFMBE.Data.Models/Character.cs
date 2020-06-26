namespace SFMBE.Data.Models
{
  using SFMBE.Data.Common.Models;

  public class Character : BaseModel<int>
  {
    public string Name { get; set; }

    public int Level { get; set; } = 0;

    public int Money { get; set; } = 25;

    public byte[] Image { get; set; }

    public int Experience { get; set; } = 0;

    public int Stamina { get; set; } = 10;

    public int Agility { get; set; } = 10;

    public int Intelligence { get; set; } = 10;

    public int Strength { get; set; } = 10;


    public int GearId { get; set; }
    public virtual Gear Gear { get; set; } = new Gear();

    public int BagId { get; set; }
    public virtual Bag Bag { get; set; } = new Bag();

    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    public int VendorId { get; set; }
    public Vendor Vendor { get; set; }
  }
}