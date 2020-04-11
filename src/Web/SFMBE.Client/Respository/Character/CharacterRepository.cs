namespace SFMBE.Client.Respository.Character
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class CharacterRepository : ICharacterRepository
  {
    private const string URL = "api/account";
    private readonly IHttpService httpService;

    public CharacterRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<ApiResponse<>> GetCharacter(CharacterRequestModel CharacterRequestModel)

  }
}
