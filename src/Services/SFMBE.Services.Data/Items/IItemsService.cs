﻿namespace SFMBE.Services.Data.Items
{
  using SFMBE.Data.Models;
  using SFMBE.Shared.Items.Create;
  using SFMBE.Shared.Items.Equip;
  using SFMBE.Shared.Items.GetItems;
  using SFMBE.Shared.Items.Unequip;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  public interface IItemsService
  {
    Task<CreateItemResponse> CreateItem(CreateItemRequest userModel);
    Task<T> GetItemById<T>(int id);
    Task<T> GetItemsByCharacterId<T>(int characterId);
    Task<ICollection<Item>> GetItemsByCharacterId(int characterId);
    Task<Item> GetItemById(int id);
    Task Unequip(UnequipItemRequest unequipItemRequest);
    Task Equip(EquipItemRequest equipItemRequest);
    Task<T> GetItemsByVendorId<T>(int vendorId);
    Task<ICollection<Item>> GetItemsByVendorId(int vendorId);
  }
}
