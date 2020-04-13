namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Services.Data.Character;
  using SFMBE.Shared;
  using SFMBE.Shared.Character;
  using System.Threading.Tasks;

  public class CharactersController : BaseController
  {
    private readonly ICharacterService characterService;

    public CharactersController(ICharacterService characterService)
    {
      this.characterService = characterService;
    }

    [Route("GetCharacter")]
    public async Task<ActionResult<ApiResponse<CharacterResponseModel>>> GetCharacter()
    {
      var response = await this.characterService.GetCurrentCharacter();

      if (response is null)
      {
        return this.BadRequest("Not found character, please create to begin.");
      }

      return this.Ok(response.ToApiResponse());
    }

    [Route("{characterId:int}")]
    public async Task<ActionResult<ApiResponse<CharacterResponseModel>>> GetCharacterById(int characterId)
    {
      var response = await this.characterService.GetCharacterById(characterId);

      if (response is null)
      {
        return this.BadRequest();
      }

      return this.Ok(response.ToApiResponse());
    }

    [HttpPost]
    [Route(nameof(CreateCharacter))]
    public async Task<ActionResult<ApiResponse<CharacterResponseModel>>> CreateCharacter([FromBody] string name)
    {
      var response = await this.characterService.CreateCharacter(name);

      return this.Ok(response.ToApiResponse());
    }
  }
}
