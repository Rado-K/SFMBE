namespace SFMBE.Services.Data.Character
{
  using SFMBE.Shared.Character;
  using System.Threading.Tasks;

  public interface ICharacterService
  {
    Task<int> CreateCharacter(string name);
    Task<CharacterResponseModel> GetCharacterById(int characterId);
  }
}
