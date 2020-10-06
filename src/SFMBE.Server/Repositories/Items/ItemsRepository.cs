namespace SFMBE.Server.Repositories.Items
{
  using System.Threading.Tasks;
  using System;
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Models;
  using SFMBE.Data;
  using SFMBE.Shared.Items.Commands;

  public class ItemsRepository : IItemsRepository
  {
    private readonly ApplicationDbContext db;

    public ItemsRepository(ApplicationDbContext db)
    {
      this.db = db;
    }

    public async Task<int> Create(CreateItemCommand createItemCommand)
    {
      var rnd = new Random();

      var averageStats = createItemCommand.Stamina + createItemCommand.Stamina + createItemCommand.Stamina + createItemCommand.Agility + createItemCommand.Level;

      var item = new Item();

      if (createItemCommand.VendorId is null)
      {
        item.ItemType = Enum.Parse<ItemType>(createItemCommand.ItemType);
        item.Level = rnd.Next(createItemCommand.Level - 1, createItemCommand.Level + 1);
        item.Stamina = rnd.Next(0, createItemCommand.Stamina / 2);
        item.Strength = rnd.Next(0, createItemCommand.Strength / 2);
        item.Agility = rnd.Next(0, createItemCommand.Agility / 2);
        item.Intelligence = rnd.Next(0, createItemCommand.Intelligence / 2);
        item.Price = rnd.Next(averageStats, averageStats * rnd.Next(1, 4));
        item.CharacterId = createItemCommand.CharacterId;
      }
      else
      {
        item.ItemType = Enum.Parse<ItemType>(createItemCommand.ItemType);
        item.Level = rnd.Next(createItemCommand.Level - 1, createItemCommand.Level + 1);
        item.Stamina = rnd.Next(0, createItemCommand.Stamina / 2);
        item.Strength = rnd.Next(0, createItemCommand.Strength / 2);
        item.Agility = rnd.Next(0, createItemCommand.Agility / 2);
        item.Intelligence = rnd.Next(0, createItemCommand.Intelligence / 2);
        item.Price = rnd.Next(averageStats, averageStats * rnd.Next(1, 4));
        item.VendorId = createItemCommand.VendorId;
      }

      await this.db.AddAsync(item);
      await this.db.SaveChangesAsync();

      return item.Id;
    }

    public async Task Equip(EquipItemCommand equipItemCommand)
    {
      var item = await this.db
        .Items
        .FirstOrDefaultAsync(x => x.Id == equipItemCommand.ItemId);
      item.IsEquip = EquipType.InGear;

      this.db.Entry(item).State = EntityState.Modified;
      await this.db.SaveChangesAsync();
    }

    public async Task Unequip(UnquipItemCommand unquipItemCommand)
    {
      var item = await this.db
        .Items
        .FirstOrDefaultAsync(x => x.Id == unquipItemCommand.ItemId);

      item.IsEquip = EquipType.InBag;

      this.db.Entry(item).State = EntityState.Modified;
      await this.db.SaveChangesAsync();
    }
  }
}