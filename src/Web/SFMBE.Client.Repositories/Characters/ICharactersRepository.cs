﻿namespace SFMBE.Client.Repositories.Characters
{
  using SFMBE.Shared;
  using SFMBE.Shared.Character.Create;
  using SFMBE.Shared.Character.Get;
  using SFMBE.Shared.Character.Update;
  using System.Threading.Tasks;

  public interface ICharactersRepository
  {
    Task<ApiResponse<CreateCharacterResponse>> CreateCharacter(string name);
    Task<ApiResponse<GetCharacterResponse>> GetCharacter(int characterId);
    Task<ApiResponse<UpdateCharacter>> UpdateCharacter(UpdateCharacter characterResponseModel);
  }
}
