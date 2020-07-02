namespace SFMBE.Services.Data.Character
{
  using SFMBE.Data.Models;
  using SFMBE.Shared.Character.Create;
  using SFMBE.Shared.Character.Update;
  using System.Threading.Tasks;

  public interface ICharactersService
  {
    Task<CreateCharacterResponse> CreateCharacter(string name);
    Task<T> GetCharacter<T>();
    Task<Character> GetCharacterById(int characterId);
    Task<T> GetCharacterById<T>(int characterId);
    Task<UpdateCharacter> UpdateCharacter(UpdateCharacter characterResponseModel);
  }
}
