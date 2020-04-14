namespace SFMBE.Client.Respository.Characters
{
  using SFMBE.Shared;
  using SFMBE.Shared.Character;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public interface ICharactersRepository
  {
    Task<ApiResponse<CharacterCreateResponseModel>> CreateCharacter(string name);
    Task<ApiResponse<CharacterResponseModel>> GetCharacter(int characterId);
    Task<ApiResponse<CharacterResponseModel>> GetCharacter();
    Task<ApiResponse<CharacterResponseModel>> UpdateCharacter(CharacterResponseModel characterResponseModel);
  }
}
