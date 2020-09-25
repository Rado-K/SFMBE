namespace SFMBE.Server.Repositories.Characters
{
  using System;
  using System.Threading.Tasks;
  using SFMBE.Data;
  using SFMBE.Data.Models;

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
  }
}