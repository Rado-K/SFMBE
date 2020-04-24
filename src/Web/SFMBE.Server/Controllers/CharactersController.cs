namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Services.Data.Character;
  using SFMBE.Shared;
  using SFMBE.Shared.Character;
  using System.Threading.Tasks;

  public class CharactersController : BaseController
  {
    private readonly ICharactersService characterService;

    public CharactersController(ICharactersService characterService)
    {
      this.characterService = characterService;
    }

    [Route(nameof(GetCharacter))]
    public async Task<ActionResult<ApiResponse<CharacterResponseModel>>> GetCharacter()
    {
      var response = await this.characterService.GetCharacter<CharacterResponseModel>();

      if (response is null)
      {
        return this.BadRequest("Not found character, please create to begin.");
      }

      return this.Ok(response.ToApiResponse());
    }

    [Route("{id:int}")]
    public async Task<ActionResult<ApiResponse<CharacterResponseModel>>> GetCharacterById([FromBody] int id)
    {
      var response = await this.characterService.GetCharacter<CharacterResponseModel>();

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

    [HttpPut]
    public async Task<ActionResult<ApiResponse<CharacterUpdateModel>>> UpdateCharacter([FromBody] CharacterUpdateModel characterResponseModel)
    {
      var response = await this.characterService.UpdateCharacter(characterResponseModel);

      return this.Ok(response.ToApiResponse());
    }
  }
}
