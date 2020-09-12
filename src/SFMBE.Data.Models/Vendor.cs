namespace SFMBE.Data.Models
{
  using System.Collections.Generic;
  using SFMBE.Data.Common.Models;

  public class Vendor : BaseModel<int>
  {
    public string Name { get; set; }

    public ICollection<Item> Items { get; set; } = new HashSet<Item>();

    public Character Character { get; set; }
  }
}
