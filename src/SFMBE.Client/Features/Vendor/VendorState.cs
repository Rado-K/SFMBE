namespace SFMBE.Client.Features.Vendor
{
  using BlazorState;
  using SFMBE.Shared.Vendors;

  public partial class VendorState : State<VendorState>
  {
    public GetVendorQueryResponse Vendor { get; set; }

    public override void Initialize() { }
  }
}
