﻿namespace SFMBE.Shared.Bags.Get
{
  using AutoMapper;
  using SFMBE.Services.Mapping;
  using System.Collections.Generic;

  public class GetBagResponse : IMapFrom<IEnumerable<int>>, IHaveCustomMappings
  {
    public IList<int> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<IEnumerable<int>, GetBagResponse>()
        .ForMember(
              d => d.Items,
              o => o.MapFrom(
                  c => c));
    }
  }
}
