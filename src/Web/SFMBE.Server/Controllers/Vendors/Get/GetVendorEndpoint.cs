namespace SFMBE.Server.Controllers.Vendors.Get
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared;
  using SFMBE.Shared.Vendors.Get;
  using System.Threading.Tasks;

  public class GetVendorEndpoint : BaseEndpoint<GetVendorRequest, ApiResponse<GetVendorResponse>>
  {
    [HttpGet(GetVendorRequest.Route)]
    public async Task<IActionResult> Process([FromQuery] GetVendorRequest request)
      => await this.Send(request);
  }
}
