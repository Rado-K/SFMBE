namespace SFMBE.Shared.Bags.Get
{
  using AutoMapper;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items.Get;
  using System.Collections.Generic;
  using System.Linq;

  public class GetBagResponse : IMapFrom<Bag>, IHaveCustomMappings
  {
    public IList<GetItemResponse> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<Bag, GetBagResponse>()
        .ForMember(
              d => d.Items,
              o => o.MapFrom(
                  c => c.Items));
    }
  }
}
