namespace SFMBE.Server.Repositories.Characters
{
  using System.Linq;
  using System.Threading.Tasks;
  using SFMBE.Data.Models;
  using AutoMapper;
  using SFMBE.Data;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Characters.Queries;

  public class CharactersRepository : ICharactersRepository
  {
    private readonly ApplicationDbContext db;
    private readonly IUsersRepository usersRepository;

    public CharactersRepository(ApplicationDbContext db, IUsersRepository usersRepository)
    {
      this.db = db;
      this.usersRepository = usersRepository;
    }

    public async Task<int?> Create(string name)
    {
      var character = new Character { Name = name };
      character.User = await this.usersRepository.GetUser();

      await this.db.Characters.AddAsync(character);
      await this.db.SaveChangesAsync();

      if (character.Id == 0)
      {
        return null;
      }

      return character.Id;
    }

    public async Task < (GetCharacterQueryResponse, string) > Get()
    {
      var userId = (await this.usersRepository.GetUser())?.Id;

      if (string.IsNullOrEmpty(userId))
      {
        return (default, "You're not log in.");
      }

      var character = this.db
        .Characters
        .Where(x => x.UserId == userId)
        .To<GetCharacterQueryResponse>()
        .FirstOrDefault();

      if (character is null)
      {
        return (default, "Character not found");
      }

      return (character, default);
    }
  }
}