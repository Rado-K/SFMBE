namespace SFMBE.Client.Features.Vendor
{
  using SFMBE.Shared.Vendors;

  public partial class Vendor
  {
    public GetVendorQueryResponse VendorModel => this.VendorState.Vendor;
  }
}
