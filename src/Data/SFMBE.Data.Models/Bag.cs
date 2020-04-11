namespace SFMBE.Data.Models
{
  using SFMBE.Data.Common.Models;
  using System;
  using System.Collections.Generic;

  public class Bag : BaseDeletableModel<int>
  {
    private const int InitialCapacity = 10;

    public int Capacity { get; set; } = InitialCapacity;

    public virtual ICollection<Item> Items { get; set; } = new HashSet<Item>();

    public virtual Character Character { get; set; }
  }
}