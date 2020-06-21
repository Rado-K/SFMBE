namespace SFMBE.Server.Controllers.Characters.Get
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared;
  using SFMBE.Shared.Character.Get;
  using System.Threading.Tasks;

  public class GetCharacterEndpoint : BaseEndpoint<GetCharacterRequest, ApiResponse<GetCharacterResponse>>
  {
    [HttpGet(GetCharacterRequest.Route)]
    public async Task<IActionResult> Process([FromQuery] GetCharacterRequest request)
      => await this.Send(request);
  }
}
