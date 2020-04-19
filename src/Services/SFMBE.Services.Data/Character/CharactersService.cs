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
      var user = await this.userService.GetUser();

      user.Character = character;

      await this.characterRepository.AddAsync(character);
      await this.characterRepository.SaveChangesAsync();

      return new CharacterCreateResponseModel { Id = character.Id };
    }

    public async Task<CharacterResponseModel> GetCurrentCharacter()
    {
      var user = await this.userService.GetUser();

      if (user.CharacterId.HasValue)
      {
        return await this.GetCharacterById(user.CharacterId.Value);
      }

      return default;
    }

    public async Task<bool> HaveCharacter()
    {
      return await this.userService.CurrentUserHasCharacter();
    }

    public async Task<CharacterResponseModel> UpdateCharacter(CharacterResponseModel characterResponseModel)
    {
      var character = await this.characterRepository
        .All()
        .FirstOrDefaultAsync(x => x.Name == characterResponseModel.Name);

      character.Level = characterResponseModel.Level;
      character.Money = characterResponseModel.Money;
      character.Stamina = characterResponseModel.Stamina;
      character.Strength = characterResponseModel.Strength;
      character.Agility = characterResponseModel.Agility;
      character.Intelligence = characterResponseModel.Intelligence;

      await this.characterRepository.SaveChangesAsync();

      return await this.GetCurrentCharacter();
    }
  }
}
