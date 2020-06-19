namespace SFMBE.Shared.Items.GetItems
{
  using AutoMapper;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items.Get;
  using System.Collections.Generic;

  public class GetItemsResponse : IMapFrom<IList<GetItemResponse>>, IHaveCustomMappings
  {
    public List<GetItemResponse> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<IList<GetItemResponse>, GetItemsResponse>()
        .ForMember(d => d.Items, o => o.MapFrom(s => s));
    }
  }
}
