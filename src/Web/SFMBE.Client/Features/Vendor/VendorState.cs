﻿namespace SFMBE.Client.Features.Vendor
{
  using BlazorState;
  using SFMBE.Shared;
  using SFMBE.Shared.Vendors.Get;

  public partial class VendorState : State<VendorState>
  {
    public ApiResponse<GetVendorResponse> Vendor { get; set; }

    public override void Initialize() { }
  }
}