namespace SFMBE.Services.Data.Gear
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Character;
  using SFMBE.Services.Data.Items;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Character;
  using System;
  using System.Linq;
  using System.Threading.Tasks;

  public class GearsService : IGearsService
  {
    private readonly IRepository<Gear> gearRepository;
    private readonly ICharactersService charactersService;
    private readonly IItemsService itemsService;

    public GearsService(
      IRepository<Gear> gearRepository,
      ICharactersService charactersService,
      IItemsService itemsService)
    {
      this.gearRepository = gearRepository;
      this.charactersService = charactersService;
      this.itemsService = itemsService;
    }

    public async Task<Gear> GetGear()
    {
      var character = await this.charactersService.GetCharacter<CharacterGetGearModel>();

      var gear = await this.gearRepository
        .GetWithProperties(x => x.Id == character.GearId, x => x.EquippedItems)
        .FirstOrDefaultAsync();

      return gear;
    }

    public async Task<T> GetGear<T>()
    {
      var gear = await this.GetGear();

      return gear.To<T>();
    }

    public async Task Equip(int id)
    {
      var character = await this.charactersService.GetCharacter<CharacterGetBagModel>();
      var item = await this.itemsService.GetItemById<Item>(id);
      var gear = await this.GetGear();

      if (character.BagId != item.BagId)
      {
        throw new InvalidOperationException();
      }

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

    public async Task Unequip(int id)
    {
      var character = await this.charactersService.GetCharacter<CharacterGetBagModel>();
      var item = await this.itemsService.GetItemById<Item>(id);
      var gear = await this.GetGear();

      if (character.BagId != item.BagId)
      {
        throw new InvalidOperationException();
      }

      if (gear.EquippedItems.Any(x => x.ItemType == item.ItemType))
      {
        gear
          .EquippedItems
          .Remove(
              gear.EquippedItems.First(x => x.ItemType == item.ItemType));

        await this.gearRepository.SaveChangesAsync();
      }
    }

  }
}
