namespace SFMBE.Client.Features.Vendor
{
  using SFMBE.Shared.Vendors.Get;

  public partial class Vendor
  {
    public GetVendorResponse VendorModel => this.VendorState.Vendor.Data;
  }
}
