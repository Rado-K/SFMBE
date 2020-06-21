namespace SFMBE.Server.Controllers.Characters.Create
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared;
  using SFMBE.Shared.Character.Create;
  using System.Threading.Tasks;

  public class CreateCharacterEndpoint : BaseEndpoint<CreateCharacterRequest, ApiResponse<CreateCharacterResponse>>
  {
    [HttpPost(CreateCharacterRequest.Route)]
    public async Task<IActionResult> Process([FromBody] CreateCharacterRequest request)
      => await this.Send(request);
  }
}
