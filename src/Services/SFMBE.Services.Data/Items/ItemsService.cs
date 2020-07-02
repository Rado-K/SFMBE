namespace SFMBE.Services.Data.Items
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Character;
  using SFMBE.Services.Data.Gear;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Character.GetBag;
  using SFMBE.Shared.Items.Create;
  using SFMBE.Shared.Items.Equip;
  using SFMBE.Shared.Items.Get;
  using SFMBE.Shared.Items.GetItems;
  using SFMBE.Shared.Items.Unequip;
  using System;
  using System.Linq;
  using System.Threading.Tasks;

  public class ItemsService : IItemsService
  {
    private readonly IDeletableEntityRepository<Item> itemsRepository;
    private readonly IRepository<Gear> gearRepository;
    private readonly ICharactersService charactersService;
    private readonly IGearsService gearsService;

    public ItemsService(
      IDeletableEntityRepository<Item> itemsRepository,
      IRepository<Gear> gearRepository,
      ICharactersService charactersService,
      IGearsService gearsService)
    {
      this.itemsRepository = itemsRepository;
      this.gearRepository = gearRepository;
      this.charactersService = charactersService;
      this.gearsService = gearsService;
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

    public async Task<T> GetItemsById<T>(GetItemsRequest itemsRequestModel)
    {
      var items = await this.itemsRepository
        .All()
        .Where(x => itemsRequestModel.Items.Contains(x.Id))
        .To<GetItemResponse>()
        .ToListAsync();

      return items.To<T>();
    }


    public async Task Equip(EquipItemRequest equipItemRequest)
    {
      var (character, item, gear) = await this.GetEntities(equipItemRequest.ItemId);

      if (gear.EquippedItems.Any(x => x.ItemType == item.ItemType))
      {
        gear
          .EquippedItems
          .Remove(
              gear.EquippedItems.First(x => x.ItemType == item.ItemType));
      }

      gear.EquippedItems.Add(item);

      await this.gearRepository.SaveChangesAsync();
    }

    public async Task Unequip(UnequipItemRequest unequipItemRequest)
    {
      var (character, item, gear) = await this.GetEntities(unequipItemRequest.ItemId);

      if (gear.EquippedItems.Any(x => x.ItemType == item.ItemType))
      {
        gear
          .EquippedItems
          .Remove(
              gear.EquippedItems.First(x => x.ItemType == item.ItemType));

        await this.gearRepository.SaveChangesAsync();
      }
    }

    private async Task<(GetBagCharacterResponse character, Item item, Gear gear)> GetEntities(int itemId)
    {
      var character = await this.charactersService.GetCharacter<GetBagCharacterResponse>();
      var item = await this.GetItemById<Item>(itemId);
      var gear = await this.gearsService.GetGear();

      if (character.BagId != item.BagId)
      {
        throw new InvalidOperationException();
      }

      return (character, item, gear);
    }
  }
}
