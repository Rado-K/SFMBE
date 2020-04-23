namespace SFMBE.Data.Models
{
  using Common.Models;
  using System.Collections.Generic;

  public class Gear : BaseModel<int>
  {
    public virtual ICollection<Item> EquippedItems { get; set; } = new HashSet<Item>();

    public virtual Character Character { get; set; }
  }
}