namespace SFMBE.Services.Data.Character
{
  using SFMBE.Shared.Character;
  using System.Threading.Tasks;

  public interface ICharactersService
  {
    Task<CharacterCreateResponseModel> CreateCharacter(string name);
    Task<T> GetCharacter<T>();
    Task<CharacterUpdateModel> UpdateCharacter(CharacterUpdateModel characterResponseModel);
  }
}
