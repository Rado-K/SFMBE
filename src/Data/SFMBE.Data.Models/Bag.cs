namespace SFMBE.Data.Models
{
  using SFMBE.Data.Common.Models;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  public class Bag : BaseDeletableModel<int>
  {
    private const int InitialCapacity = 10;

    [Required]
    public int Capacity { get; set; } = InitialCapacity;

    public ICollection<Item> Items { get; set; } = new HashSet<Item>();

    public Character Character { get; set; }
  }
}