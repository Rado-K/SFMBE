namespace SFMBE.Services.Data.Character
{
  using SFMBE.Shared.Character;
  using System.Threading.Tasks;

  public interface ICharactersService
  {
    Task<CharacterCreateResponseModel> CreateCharacter(string name);
    Task<CharacterResponseModel> GetCharacterById(int characterId);
    Task<CharacterResponseModel> GetCurrentCharacter();
    Task<bool> HaveCharacter();
    Task<CharacterResponseModel> UpdateCharacter(CharacterResponseModel characterResponseModel);
  }
}
