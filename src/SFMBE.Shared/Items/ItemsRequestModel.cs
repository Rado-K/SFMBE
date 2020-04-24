namespace SFMBE.Shared.Items
{
  using AutoMapper;
  using SFMBE.Services.Mapping;
  using System.Collections.Generic;
  using System.Linq;

  public class  ItemsRequestModel : IMapFrom<IList<int>>
  {
    public IList<int> Items { get; set; }
  }
}
