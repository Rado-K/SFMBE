namespace SFMBE.Shared.Gear.Get
{
  using AutoMapper;
  using SFMBE.Services.Mapping;
  using System.Collections.Generic;

  public class GetGearResponse : IMapFrom<IEnumerable<int>>, IHaveCustomMappings
  {
    public IList<int> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<IEnumerable<int>, GetGearResponse>()
        .ForMember(d => d.Items,
              o => o.MapFrom(c => c));
    }
  }
}
