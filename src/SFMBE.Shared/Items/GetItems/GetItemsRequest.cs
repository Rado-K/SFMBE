namespace SFMBE.Shared.Items.GetItems
{
  using AutoMapper;
  using SFMBE.Services.Mapping;
  using System.Collections.Generic;

  public class GetItemsRequest : IMapFrom<IList<int>>, IHaveCustomMappings
  {
    public IList<int> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<IList<int>, GetItemsRequest>()
        .ForMember(d => d.Items, o => o.MapFrom(c => c));
    }
  }
}
