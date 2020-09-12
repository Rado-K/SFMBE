namespace SFMBE.Data.Specifications.Vendors
{
  using Ardalis.Specification;
  using SFMBE.Data.Models;

  public sealed class GetVendorSpecification : Specification<Vendor>
  {
    public GetVendorSpecification(int vendorId)
    {
      this.Query
        .Where(x => x.Id == vendorId)
        .Include(x => x.Items);
    }
  }
}
