namespace SFMBE.Data.Models
{
  using SFMBE.Data.Common.Models;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  public class Character : BaseModel<int>
  {
    [Required]
    public string Name { get; set; }

    public int Level { get; set; } = 0;

    public int Money { get; set; } = 25;

    public byte[] Image { get; set; }

    public int Experience { get; set; } = 0;

    public int Stamina { get; set; } = 10;

    public int Agility { get; set; } = 10;

    public int Intelligence { get; set; } = 10;

    public int Strength { get; set; } = 10;

    public ICollection<Item> Items { get; set; } = new HashSet<Item>();

    [Required]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    [Required]
    public int VendorId { get; set; }
    public Vendor Vendor { get; set; } = new Vendor();
  }
}