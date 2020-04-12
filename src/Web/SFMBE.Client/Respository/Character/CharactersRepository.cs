namespace SFMBE.Client.Respository.Character
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Character;
  using System;
  using System.Threading.Tasks;

  public class CharactersRepository : ICharactersRepository
  {
    private const string URL = "api/character";
    private readonly IHttpService httpService;

    public CharactersRepository(IHttpService httpService)
    {
      this.httpService = httpService;
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

    public async Task<ApiResponse<int>> CreateCharacter(string name)
    {
      var httpResponse = await this.httpService.PostJson<string, int>(URL, name);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<int>(httpResponse.Errors);
      }

      return httpResponse;
    }
  }
}
