namespace SFMBE.Server.Controllers.Bags.Get
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared;
  using SFMBE.Shared.Bags.Get;
  using System.Threading.Tasks;

  public class GetBagEndpoint : BaseEndpoint<GetBagRequest, ApiResponse<GetBagResponse>>
  {
    [HttpGet(GetBagRequest.Route)]
    public async Task<IActionResult> Process([FromQuery] GetBagRequest request)
      => await this.Send(request);
  }
}
