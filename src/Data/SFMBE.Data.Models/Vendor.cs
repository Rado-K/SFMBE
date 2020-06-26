namespace SFMBE.Data.Models
{
  using SFMBE.Data.Common.Models;
  using System.Collections.Generic;

  public class Vendor : BaseModel<int>
  {
    public string Name { get; set; }

    public ICollection<Item> Items { get; set; } = new HashSet<Item>();

    public Character Character { get; set; }
  }
}
