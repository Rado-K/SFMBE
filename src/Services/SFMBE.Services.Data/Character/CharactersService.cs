namespace SFMBE.Services.Data.Character
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Items;
  using SFMBE.Services.Data.User;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Character.Create;
  using SFMBE.Shared.Character.Update;
  using System.Linq;
  using System.Threading.Tasks;

  public class CharactersService : ICharactersService
  {
    private readonly IRepository<Character> characterRepository;
    private readonly IUserService userService;
    private readonly IItemsService itemsService;

    public CharactersService(
      IRepository<Character> characterRepository,
      IUserService userService,
      IItemsService itemsService)
    {
      this.characterRepository = characterRepository;
      this.userService = userService;
      this.itemsService = itemsService;
    }

    public async Task<Character> GetCharacterById(int characterId)
    {
      var character = await this.characterRepository
        .All()
        .Where(x => x.Id == characterId)
        .FirstOrDefaultAsync();

      var items = await this.itemsService.GetItemsByCharacterId(characterId);

      character.Items = items;

      return character;
    }

    public async Task<T> GetCharacterById<T>(int characterId)
    {
      var character = await this.GetCharacterById(characterId);

      return character.To<T>();
    }

    public async Task<CreateCharacterResponse> CreateCharacter(string name)
    {
      var character = new Character { Name = name };
      character.User = await this.userService.GetUser();

      await this.characterRepository.AddAsync(character);
      await this.characterRepository.SaveChangesAsync();

      return character.To<CreateCharacterResponse>();
    }

    public async Task<T> GetCharacter<T>()
    {
      var user = await this.userService.GetUser(x => x.Character);

      var character = await this.GetCharacterById<T>(user.Character.Id);

      return character;
    }

    public async Task<UpdateCharacter> UpdateCharacter(UpdateCharacter characterUpdateModel)
    {
      var character = await this.characterRepository
        .All()
        .FirstOrDefaultAsync(x => x.Name == characterUpdateModel.Name);

      MappingExtensions.To(characterUpdateModel, character);

      this.characterRepository.Update(character);
      await this.characterRepository.SaveChangesAsync();

      return character.To<UpdateCharacter>();
    }
  }
}
