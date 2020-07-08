namespace SFMBE.Shared.Vendors.Get
{
  using AutoMapper;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items.Get;
  using System.Collections.Generic;

  public class GetVendorResponse : IMapFrom<Vendor>, IHaveCustomMappings
  {
    public IList<GetItemResponse> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<Vendor, GetVendorResponse>()
        .ForMember(
              d => d.Items,
              o => o.MapFrom(
                  c => c.Items));
    }
  }
}
