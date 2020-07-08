namespace SFMBE.Shared.Gear.Get
{
  using AutoMapper;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items.Get;
  using System.Collections.Generic;

  public class GetGearResponse : IMapFrom<Gear>, IHaveCustomMappings
  {
    public IList<GetItemResponse> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<Gear, GetGearResponse>()
        .ForMember(
              d => d.Items,
              o => o.MapFrom(
                  c => c.EquippedItems));
    }
  }
}
