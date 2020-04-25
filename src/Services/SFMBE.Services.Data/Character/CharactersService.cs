namespace SFMBE.Services.Data.Character
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.User;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Character;
  using System.Linq;
  using System.Threading.Tasks;

  public class CharactersService : ICharactersService
  {
    private readonly IRepository<Character> characterRepository;
    private readonly IUserService userService;

    public CharactersService(IRepository<Character> characterRepository, IUserService userService)
    {
      this.characterRepository = characterRepository;
      this.userService = userService;
    }

    public async Task<CharacterResponseModel> GetCharacterById(int characterId)
    {
      var character = await this.characterRepository
        .All()
        .Where(x => x.Id == characterId)
        .To<CharacterResponseModel>()
        .FirstOrDefaultAsync();

      return character;
    }

    public async Task<CharacterCreateResponseModel> CreateCharacter(string name)
    {
      var character = new Character { Name = name };
      character.User = await this.userService.GetUser();

      await this.characterRepository.AddAsync(character);
      await this.characterRepository.SaveChangesAsync();

      return character.To<CharacterCreateResponseModel>();
    }

    public async Task<T> GetCharacter<T>()
    {
      var user = await this.userService.GetUser(x => x.Character);

      if (user.Character is null)
      {
        return default;
      }

      return user.Character.To<T>();
    }

    public async Task<CharacterUpdateModel> UpdateCharacter(CharacterUpdateModel characterUpdateModel)
    {
      var character = await this.characterRepository
        .All()
        .FirstOrDefaultAsync(x => x.Name == characterUpdateModel.Name);

      MappingExtensions.To(characterUpdateModel, character);

      this.characterRepository.Update(character);
      await this.characterRepository.SaveChangesAsync();

      return character.To<CharacterUpdateModel>();
    }
  }
}
