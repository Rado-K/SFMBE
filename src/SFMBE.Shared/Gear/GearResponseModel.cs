namespace SFMBE.Shared.Gear
{
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items;
  using System.Collections.Generic;

  public class GearResponseModel : IMapFrom<Gear>
  {
    public ICollection<ItemCreateResponseModel> EquippedItems { get; set; }
  }
}
