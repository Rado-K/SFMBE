namespace SFMBE.Services.Data.Items
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items.Create;
  using SFMBE.Shared.Items.Equip;
  using SFMBE.Shared.Items.Unequip;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class ItemsService : IItemsService
  {
    private readonly IDeletableEntityRepository<Item> itemsRepository;

    public ItemsService(
      IDeletableEntityRepository<Item> itemsRepository)
    {
      this.itemsRepository = itemsRepository;
    }

    public async Task<CreateItemResponse> CreateItem(CreateItemRequest userModel)
    {
      var rnd = new Random();

      var averageStats = userModel.Stamina + userModel.Stamina + userModel.Stamina + userModel.Agility + userModel.Level;

      var item = new Item();

      if (userModel.VendorId is null)
      {
        item.ItemType = Enum.Parse<ItemType>(userModel.ItemType);
        item.Level = rnd.Next(userModel.Level - 1, userModel.Level + 1);
        item.Stamina = rnd.Next(0, userModel.Stamina / 2);
        item.Strength = rnd.Next(0, userModel.Strength / 2);
        item.Agility = rnd.Next(0, userModel.Agility / 2);
        item.Intelligence = rnd.Next(0, userModel.Intelligence / 2);
        item.Price = rnd.Next(averageStats, averageStats * rnd.Next(1, 4));
        item.CharacterId = userModel.CharacterId;
      }
      else
      {
        item.ItemType = Enum.Parse<ItemType>(userModel.ItemType);
        item.Level = rnd.Next(userModel.Level - 1, userModel.Level + 1);
        item.Stamina = rnd.Next(0, userModel.Stamina / 2);
        item.Strength = rnd.Next(0, userModel.Strength / 2);
        item.Agility = rnd.Next(0, userModel.Agility / 2);
        item.Intelligence = rnd.Next(0, userModel.Intelligence / 2);
        item.Price = rnd.Next(averageStats, averageStats * rnd.Next(1, 4));
        item.VendorId = userModel.VendorId;
      }

      await this.itemsRepository.AddAsync(item);
      await this.itemsRepository.SaveChangesAsync();

      return item.To<CreateItemResponse>();
    }

    public async Task<Item> GetItemById(int id)
    {
      var item = await this.itemsRepository
        .All()
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();

      return item;
    }

    public async Task<T> GetItemById<T>(int id)
    {
      var item = await this.GetItemById(id);

      return item.To<T>();
    }

    public async Task<ICollection<Item>> GetItemsByCharacterId(int characterId)
    {
      var items = await this.itemsRepository
        .All()
        .Where(x => x.CharacterId == characterId)
        .ToListAsync();

      return items;
    }

    public async Task<T> GetItemsByCharacterId<T>(int characterId)
    {
      var items = await this.GetItemsByCharacterId(characterId);

      return items.To<T>();
    }

    public async Task<ICollection<Item>> GetItemsByVendorId(int vendorId)
    {
      var items = await this.itemsRepository
        .All()
        .Where(x => x.VendorId == vendorId && x.IsEquip == EquipType.InVendor)
        .ToListAsync();

      return items;
    }

    public async Task<T> GetItemsByVendorId<T>(int vendorId)
    {
      var items = await this.GetItemsByVendorId(vendorId);

      return items.To<T>();
    }

    public async Task Equip(EquipItemRequest equipItemRequest)
    {
      var item = await this.GetItemById(equipItemRequest.ItemId);

      item.IsEquip = EquipType.InGear;

      await this.itemsRepository.SaveChangesAsync();
    }

    public async Task Unequip(UnequipItemRequest unequipItemRequest)
    {
      var item = await this.GetItemById(unequipItemRequest.ItemId);

      item.IsEquip = EquipType.InBag;

      await this.itemsRepository.SaveChangesAsync();
    }
  }
}
