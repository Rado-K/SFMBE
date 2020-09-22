namespace SFMBE.Shared.Vendors
{
  using System.Collections.Generic;
  using AutoMapper;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items.Queries;

  public class GetVendorQueryResponse : IMapFrom<Vendor>, IHaveCustomMappings
  {
    public IEnumerable<GetItemQueryResponse> Items { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<Vendor, GetVendorQueryResponse>()
        .ForMember(
              d => d.Items,
              o => o.MapFrom(
                  c => c.Items));
    }
  }
}
