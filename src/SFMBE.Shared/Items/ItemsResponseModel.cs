namespace SFMBE.Shared.Items
{
  using AutoMapper;
  using SFMBE.Services.Mapping;
  using System.Collections.Generic;
  using System.Linq;

  public class ItemsResponseModel : IMapFrom<IList<ItemResponseModel>>, IHaveCustomMappings
  {
    public List<ItemResponseModel> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<IList<ItemResponseModel>, ItemsResponseModel>()
        .ForMember(d => d.Items, o => o.MapFrom(s => s));
    }
  }
}
