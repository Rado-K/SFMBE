namespace SFMBE.Data.Seeding
{
  using System;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.Extensions.DependencyInjection;
  using SFMBE.Data.Models;

  internal class UsersSeeder : ISeeder
  {
    public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
    {
      var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

      await SeedUsers(userManager);
    }

    private static async Task SeedUsers(UserManager<ApplicationUser> userManager)
    {
      var users = new[]
      {
          new ApplicationUser
          {
            Id = "00000000-0000-0000-0000-000000000000",
            UserName = "user1",
            Email = $"user1@localhost",
          },
          new ApplicationUser
          {
            Id = "00000000-1111-0000-0000-000000000000",
            UserName = "user2",
            Email = $"user2@localhost",
          },
      };

      foreach (var user in users)
      {
        if (await userManager.FindByNameAsync(user.UserName) == null)
        {
          await userManager.CreateAsync(user, password: user.UserName + user.UserName);
        }
      }
    }
  }
}
