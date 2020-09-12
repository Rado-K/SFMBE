namespace SFMBE.Data.Seeding
{
  using System;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Models;

  internal class CharactersSeeder : ISeeder
  {
    public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
    {
      if (dbContext.Characters.Any())
      {
        return;
      }

      await SeedCharacters(dbContext);
    }

    private static async Task SeedCharacters(ApplicationDbContext db)
    {
      var users = new[] { "user1", "user2" };
      var characters = new[] { "character1", "character2" };

      for (int i = 0; i < characters.Length; i++)
      {
        if (await db.Characters.FirstOrDefaultAsync(x => x.Name == characters[i]) == null)
        {
          var character = new Character { Name = characters[i] };
          character.User = await db.Users.FirstOrDefaultAsync(x => x.UserName == users[i]);
          await db.AddAsync(character);
        }
      }
    }
  }
}
