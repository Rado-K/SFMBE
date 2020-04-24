namespace SFMBE.Shared.Items
{
  using AutoMapper;
  using SFMBE.Services.Mapping;
  using System.Collections.Generic;
  using System.Linq;

  public class  ItemsRequestModel : IMapFrom<IList<int>>, IHaveCustomMappings
  {
    public IList<int> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<IList<int>, ItemsRequestModel>()
        .ForMember(d => d.Items, o => o.MapFrom(c => c));
    }
  }
}
