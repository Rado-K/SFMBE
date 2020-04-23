namespace SFMBE.Services.Data.Character
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.User;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Character;
  using System.Linq;
  using System.Security.Cryptography.X509Certificates;
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

      return new CharacterCreateResponseModel { Id = character.Id };
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

    public async Task<CharacterResponseModel> UpdateCharacter(CharacterResponseModel characterResponseModel)
    {
      var character = await this.characterRepository
        .All()
        .FirstOrDefaultAsync(x => x.Name == characterResponseModel.Name);

      character = characterResponseModel.To<Character>();


      await this.characterRepository.SaveChangesAsync();

      return await this.GetCharacter<CharacterResponseModel>();
    }
  }
}
