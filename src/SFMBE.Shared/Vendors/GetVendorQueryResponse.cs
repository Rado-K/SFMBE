namespace SFMBE.Shared.Vendors
{
  using System.Collections.Generic;
  using System.Linq;
  using SFMBE.Data.Models;
  using SFMBE.Shared.Items.Queries;

  public class GetVendorQueryResponse
  {
    public IEnumerable<GetItemQueryResponse> Items { get; set; }

    public static GetVendorQueryResponse FromVendor(Vendor vendor)
    {
      return new GetVendorQueryResponse
      {
        Items = vendor.Items.Select(GetItemQueryResponse.FromItem)
      };
    }
  }
}
