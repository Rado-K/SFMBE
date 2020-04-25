﻿namespace SFMBE.Shared.Gear
{
  using AutoMapper;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using System.Collections.Generic;
  using System.Linq;

  public class GearResponseModel : IMapFrom<Gear>, IHaveCustomMappings
  {
    public IList<int> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<Gear, GearResponseModel>()
        .ForMember(d => d.Items, o => o.MapFrom(c => c.EquippedItems.Select(x => x.Id)));
    }
  }
}
