namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Services.Data.Character;
  using SFMBE.Shared;
  using SFMBE.Shared.Character.Get;
  using SFMBE.Shared.Character.Update;
  using System.Threading.Tasks;

  public class CharactersController : BaseController
  {
    private readonly ICharactersService characterService;

    public CharactersController(ICharactersService characterService)
    {
      this.characterService = characterService;
    }

    [Route(nameof(GetCharacter))]
    public async Task<ActionResult<ApiResponse<GetCharacterResponse>>> GetCharacter()
    {
      var response = await this.characterService.GetCharacter<GetCharacterResponse>();

      if (response is null)
      {
        return this.BadRequest("Not found character, please create to begin.");
      }

      return this.Ok(response.ToApiResponse());
    }

    [Route("{id:int}")]
    public async Task<ActionResult<ApiResponse<GetCharacterResponse>>> GetCharacterById([FromBody] int id)
    {
      var response = await this.characterService.GetCharacter<GetCharacterResponse>();

      if (response is null)
      {
        return this.BadRequest();
      }

      return this.Ok(response.ToApiResponse());
    }

    //[HttpPost]
    //[Route(nameof(CreateCharacter))]
    //public async Task<ActionResult<ApiResponse<GetCharacterResponse>>> CreateCharacter([FromBody] string name)
    //{
    //  var response = await this.characterService.CreateCharacter(name);

    //  return this.Ok(response.ToApiResponse());
    //}

    [HttpPut]
    public async Task<ActionResult<ApiResponse<UpdateCharacter>>> UpdateCharacter([FromBody] UpdateCharacter characterResponseModel)
    {
      var response = await this.characterService.UpdateCharacter(characterResponseModel);

      return this.Ok(response.ToApiResponse());
    }
  }
}
