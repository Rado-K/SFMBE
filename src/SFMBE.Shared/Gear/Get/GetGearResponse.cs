namespace SFMBE.Shared.Gear.Get
{
  using AutoMapper;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using System.Collections.Generic;
  using System.Linq;

  public class GetGearResponse : IMapFrom<IEnumerable<int>>, IMapFrom<Gear>, IHaveCustomMappings
  {
    public IList<int> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<IEnumerable<int>, GetGearResponse>()
        .ForMember(d => d.Items,
              o => o.MapFrom(c => c));

      configuration
        .CreateMap<Gear, GetGearResponse>()
        .ForMember(d => d.Items,
              o => o.MapFrom(c => c.EquippedItems.Select(x => x.Id  )));
    }
  }
}
