namespace SFMBE.Client.Repositories.Characters
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Character.Create;
  using SFMBE.Shared.Character.Get;
  using SFMBE.Shared.Character.Update;
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

    public async Task<ApiResponse<GetCharacterResponse>> GetCharacter()
    {
      var httpResponse = await this.httpService.Get<GetCharacterResponse>($"{URL}/GetCharacter");

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<GetCharacterResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }

    public async Task<ApiResponse<GetCharacterResponse>> GetCharacter(int characterId)
    {
      var httpResponse = await this.httpService.Get<GetCharacterResponse>($"{URL}/{characterId}");

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<GetCharacterResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }

    public async Task<ApiResponse<CreateCharacterResponse>> CreateCharacter(string name)
    {
      var request = new CreateCharacterRequest { Name = name };
      var httpResponse = await this.httpService.PostJson<CreateCharacterRequest, CreateCharacterResponse>(request.RouteFactory, request);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<CreateCharacterResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }

    public async Task<ApiResponse<UpdateCharacter>> UpdateCharacter(UpdateCharacter characterResponseModel)
    {
      var httpResponse = await this.httpService.Put(URL, characterResponseModel);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<UpdateCharacter>(httpResponse.Errors);
      }

      return httpResponse;
    }

  }
}
