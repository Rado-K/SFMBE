namespace SFMBE.Server.Repositories.Characters
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Models;
  using SFMBE.Data;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Characters.Queries;
    using SFMBE.Shared.Characters.Commands;

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

    public async Task<IEnumerable<ListCharactersQueryResponse>> GetList(string parameter)
    {
      parameter = parameter.ToLower();
      var characters = await this.db
        .Characters
        .Where(x => x.Name.ToLower().StartsWith(parameter))
        .To<ListCharactersQueryResponse>()
        .ToListAsync();

      return characters;
    }

    public async Task<UpdateCharacterCommand> Update(UpdateCharacterCommand updateCharacterCommand)
    {
      var character = await this.db
      .Characters
      .FirstOrDefaultAsync(x => x.Id == updateCharacterCommand.Id);

      MappingExtensions.To(updateCharacterCommand, character);

      this.db.Entry(character).State = EntityState.Modified;
      await this.db.SaveChangesAsync();

      return updateCharacterCommand;
    }
  }
}