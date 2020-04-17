namespace SFMBE.Shared.Bags
{
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items;
  using System.Collections.Generic;

  public class BagResponseModel : IMapFrom<Bag>
  {
    public IList<int> Items { get; set; }
  }
}
