namespace SFMBE.Data.Seeding
{
  using System;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Models;

  internal class ItemsSeeder : ISeeder
  {
    public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
    {
      if (dbContext.Items.Any())
      {
        return;
      }

      await SeedItems(dbContext);
    }

    private static async Task SeedItems(ApplicationDbContext db)
    {
      var character1 = await db.Characters
        .FirstOrDefaultAsync(x => x.Name == "character1");
      var character2 = await db.Characters
        .FirstOrDefaultAsync(x => x.Name == "character2");

      var items = new[]
      {
        new Item
        {
          ItemType = Enum.Parse<ItemType>("Sword"),
          IsEquip = Enum.Parse<EquipType>("InGear"),
          Level = 1,
          Stamina = 1,
          Strength = 1,
          Agility = 1,
          Intelligence = 1,
          Price = 1,
          CharacterId = character1.Id,
        },
        new Item
        {
          ItemType = Enum.Parse<ItemType>("Boots"),
          IsEquip = Enum.Parse<EquipType>("InBag"),
          Level = 1,
          Stamina = 1,
          Strength = 1,
          Agility = 1,
          Intelligence = 1,
          Price = 1,
          CharacterId = character2.Id,
        },
        new Item
        {
          ItemType = Enum.Parse<ItemType>("Chest"),
          IsEquip = Enum.Parse<EquipType>("InVendor"),
          Level = 1,
          Stamina = 1,
          Strength = 1,
          Agility = 1,
          Intelligence = 1,
          Price = 1,
          VendorId = character1.VendorId,
        },
        new Item
        {
          ItemType = Enum.Parse<ItemType>("Shield"),
          IsEquip = Enum.Parse<EquipType>("InVendor"),
          Level = 1,
          Stamina = 1,
          Strength = 1,
          Agility = 1,
          Intelligence = 1,
          Price = 1,
          VendorId = character2.VendorId,
        },
      };

      await db.Items.AddRangeAsync(items);
    }
  }
}
