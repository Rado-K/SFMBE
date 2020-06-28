namespace SFMBE.Server.Controllers.Gear.Get
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared;
  using SFMBE.Shared.Gear.Get;
  using System.Threading.Tasks;

  public class GetGearEndpoint : BaseEndpoint<GetGearRequest, ApiResponse<GetGearResponse>>
  {
    [HttpGet(GetGearRequest.Route)]
    public async Task<IActionResult> Process([FromQuery] GetGearRequest request)
      => await this.Send(request);
  }
}
