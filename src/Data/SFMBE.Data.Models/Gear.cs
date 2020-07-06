namespace SFMBE.Data.Models
{
  using Common.Models;
  using System.Collections.Generic;

  public class Gear : BaseModel<int>
  {
    public ICollection<Item> EquippedItems { get; set; } = new HashSet<Item>();

    public Character Character { get; set; }
  }
}