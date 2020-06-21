namespace SFMBE.Server.Controllers.Characters.Update
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared;
  using SFMBE.Shared.Character.Update;
  using System.Threading.Tasks;

  public class UpdateCharacterEndpoint : BaseEndpoint<UpdateCharacter, ApiResponse<UpdateCharacter>>
  {
    [HttpPut(UpdateCharacter.Route)]
    public async Task<IActionResult> Process([FromBody] UpdateCharacter request)
      => await this.Send(request);
  }
}
