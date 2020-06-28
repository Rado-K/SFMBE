namespace SFMBE.Shared.Vendors.Get
{
  using AutoMapper;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using System.Collections.Generic;
  using System.Linq;

  public class GetVendorResponse : IMapFrom<Vendor>, IHaveCustomMappings
  {
    public IList<int> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<Vendor, GetVendorResponse>()
        .ForMember(
              d => d.Items,
              o => o.MapFrom(
                  c => c.Items.Select(x => x.Id)));
    }
  }
}
