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
      var users = new[] { "user1", "user2" };

      foreach (var userName in users)
      {
        if (await userManager.FindByNameAsync(userName) == null)
        {
          var user = new ApplicationUser
          {
            UserName = userName,
            Email = $"{userName}@localhost",
          };

          await userManager.CreateAsync(user, password: userName + userName);
        }
      }
    }
  }
}
