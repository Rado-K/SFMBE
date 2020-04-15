﻿namespace SFMBE.Services.Data.Items
{
  using SFMBE.Data.Models;
  using SFMBE.Shared.Items;
  using System.Threading.Tasks;

  public interface IItemsService
  {
    Task<ItemsBagResponseModel> CreateItem(ItemCreateRequestModel userModel);
    T GetItemById<T>(int id);
  }
}
