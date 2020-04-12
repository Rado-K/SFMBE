﻿namespace SFMBE.Services.Data.Items
{
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class ItemsService : IItemsService
  {
    private readonly IDeletableEntityRepository<Item> itemsRepository;

    public ItemsService(IDeletableEntityRepository<Item> itemsRepository)
    {
      this.itemsRepository = itemsRepository;
    }

    public async Task<ItemResponseModel> CreateAsync(ItemStatsRequestModel userModel)
    {
      var rnd = new Random();

      var averageStats = userModel.Stamina + userModel.Stamina + userModel.Stamina + userModel.Agility + userModel.Level;

      var item = new Item
      {
        ItemType = Enum.Parse<ItemType>(userModel.ItemType),
        Level = rnd.Next(userModel.Level - 1, userModel.Level + 1),
        Stamina = rnd.Next(0, userModel.Stamina / 2),
        Strength = rnd.Next(0, userModel.Strength / 2),
        Agility = rnd.Next(0, userModel.Agility / 2),
        Intelligence = rnd.Next(0, userModel.Intelligence / 2),
        Price = rnd.Next(averageStats, averageStats * rnd.Next(1, 4)),
        BagId = userModel.BagId
      };

      await this.itemsRepository.AddAsync(item);
      await this.itemsRepository.SaveChangesAsync();

      return new ItemResponseModel { Id = item.Id };
    }

    public T GetById<T>(int id)
    {
      var post = this.itemsRepository
        .All()
        .Where(x => x.Id == id)
        .To<T>()
        .FirstOrDefault();

      return post;
    }
  }
}
