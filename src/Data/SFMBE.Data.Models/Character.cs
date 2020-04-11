// ReSharper disable VirtualMemberCallInConstructor
using SFMBE.Data.Common.Models;

namespace SFMBE.Data.Models
{
  public class Character : BaseModel<int>
  {
    public int Level { get; set; } = 0;

    public int Money { get; set; } = 25;

    public byte[] Image { get; set; }

    public int Experience { get; set; } = 0;

    public int Stamina { get; set; } = 10;

    public int Agility { get; set; } = 10;

    public int Intelligence { get; set; } = 10;

    public int Strength { get; set; } = 10;


    public int GearId { get; set; }
    public virtual Gear Gear { get; set; }

    public int BagId { get; set; }

    public virtual Bag Bag { get; set; }
  }
}