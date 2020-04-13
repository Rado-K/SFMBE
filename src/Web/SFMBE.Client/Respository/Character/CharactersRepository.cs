namespace SFMBE.Client.Respository.Character
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Character;
  using System;
  using System.Threading.Tasks;

  public class CharactersRepository : ICharactersRepository
  {
    private const string URL = "api/characters";
    private readonly IHttpService httpService;

    public CharactersRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<ApiResponse<CharacterResponseModel>> GetCharacter()
    {
      var httpResponse = await this.httpService.Get<CharacterResponseModel>($"{URL}/GetCharacter");

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<CharacterResponseModel>(httpResponse.Errors);
      }

      return httpResponse;
    }

    public async Task<ApiResponse<CharacterResponseModel>> GetCharacter(int characterId)
    {
      var httpResponse = await this.httpService.Get<CharacterResponseModel>($"{URL}/{characterId}");

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<CharacterResponseModel>(httpResponse.Errors);
      }

      return httpResponse;
    }

    public async Task<ApiResponse<CharacterCreateResponseModel>> CreateCharacter(string name)
    {
      var httpResponse = await this.httpService.PostJson<string, CharacterCreateResponseModel>($"{URL}/CreateCharacter", name);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<CharacterCreateResponseModel>(httpResponse.Errors);
      }

      return httpResponse;
    }

    public async Task<ApiResponse<bool>> TryToGetCharacter()
    {
      var httpResponse = await this.httpService.Get<bool>($"{URL}/TryToGet");

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<bool>(httpResponse.Errors);
      }

      return httpResponse;
    }
  }
}
