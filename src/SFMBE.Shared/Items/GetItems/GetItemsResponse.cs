namespace SFMBE.Shared.Items.GetItems
{
  using AutoMapper;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items.Get;
  using System.Collections.Generic;
  using System.Linq;

  public class GetItemsResponse : IMapFrom<List<Item>>, IMapFrom<List<GetItemResponse>>, IHaveCustomMappings
  {
    public List<GetItemResponse> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<List<Item>, GetItemsResponse>()
        .ForMember(d => d.Items, o => o.MapFrom(s => s.Select(x => x.To<GetItemResponse>())));

      configuration
        .CreateMap<List<GetItemResponse>, GetItemsResponse>()
        .ForMember(d => d.Items, o => o.MapFrom(s => s.Select(x => x)));
    }
  }
}
