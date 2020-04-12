namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Services.Data.Character;
  using SFMBE.Shared;
  using SFMBE.Shared.Character;
  using System;
  using System.Threading.Tasks;

  public class CharactersController : BaseController
  {
    private readonly ICharacterService characterService;

    public CharactersController(ICharacterService characterService)
    {
      this.characterService = characterService;
    }

    [Route("{characterId:int}")]
    public async Task<ActionResult<ApiResponse<CharacterResponseModel>>> GetCharacterById(int characterId)
    {
      var response = await this.characterService.GetCharacterById(characterId);

      return this.Ok(response.ToApiResponse());
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<CharacterResponseModel>>> CreateCharacter(string name)
    {
      var response = await this.characterService.CreateCharacter(name);

      return this.Ok(response.ToApiResponse());
    }
  }
}
