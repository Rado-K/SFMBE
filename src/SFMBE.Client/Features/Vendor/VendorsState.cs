namespace SFMBE.Client.Features.Vendor
{
  using BlazorState;
  using SFMBE.Shared.Vendors;

  public partial class VendorsState : State<VendorsState>
  {
    public GetVendorQueryResponse Vendor { get; set; }

    public override void Initialize() { }
  }
}
