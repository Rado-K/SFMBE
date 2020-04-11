namespace SFMBE.Data.Seeding
{
  using Microsoft.Extensions.DependencyInjection;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  internal class ItemSeeder : ISeeder
  {
    public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
    {
      if (dbContext.Items.Any())
      {
        return;
      }

      var itemsService = serviceProvider.GetRequiredService<IItemsService>();

      var itemsTypes = new List<string>
      {
        "Head",
        "Head",
        "Boots",
        "Head",
        "Chest",
        "Boots",
      };
    }

    private async Task SeedItems(IItemsService itemsService, List<string> itemsTypes)
    {
      foreach (var item in itemsTypes)
      {

      }
    }
  }
}
