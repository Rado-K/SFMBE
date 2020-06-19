namespace SFMBE.Services.Data.Items
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items.Create;
  using SFMBE.Shared.Items.Get;
  using SFMBE.Shared.Items.GetItems;
  using System;
  using System.Linq;
  using System.Threading.Tasks;

  public class ItemsService : IItemsService
  {
    private readonly IDeletableEntityRepository<Item> itemsRepository;

    public ItemsService(IDeletableEntityRepository<Item> itemsRepository)
    {
      this.itemsRepository = itemsRepository;
    }

    public async Task<CreateItemResponse> CreateItem(CreateItemRequest userModel)
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

      return new CreateItemResponse { Id = item.Id };
    }

    public async Task<T> GetItemById<T>(int id)
    {
      var item = await this.itemsRepository
        .All()
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();

      return item.To<T>();
    }

    public async Task<T> GetItemsById<T>(GetItemsRequest itemsRequestModel)
    {
      var items = await this.itemsRepository
        .All()
        .Where(x => itemsRequestModel.Items.Contains(x.Id))
        .To<GetItemResponse>()
        .ToListAsync();

      var asnwer = MappingExtensions.To<T>(items);

      return asnwer;
    }
  }
}
