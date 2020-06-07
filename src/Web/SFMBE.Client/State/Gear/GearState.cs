namespace SFMBE.Client.State.Gear
{
  using SFMBE.Client.Respository.Gears;
  using SFMBE.Client.Respository.Items;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class GearState
  {
    private readonly IGearsRepository gearsRepository;
    private readonly IItemsRepository itemsRepository;

    public GearState(IGearsRepository gearsRepository, IItemsRepository itemsRepository)
    {
      this.gearsRepository = gearsRepository;
      this.itemsRepository = itemsRepository;
    }

    public event Func<Task> OnChange;

    public List<ItemResponseModel> Gear { get; set; }

    public int BoardRows
      => this.Gear is null
        ? 0 : (int)Math.Ceiling((decimal)this.Gear.Count / 3);

    public async Task Initialize()
    {
      var gear = await this.gearsRepository.GetGear();

      var requestModel = gear.Data.Items.To<ItemsRequestModel>();

      this.Gear = (await this.itemsRepository.GetItems(requestModel)).Data.Items;

      this.Gear = this.OrderItems(this.Gear);
    }

    public async Task Equip(ItemResponseModel item)
    {
      this.Gear.Add(item);

      await this.gearsRepository.Equip(item.Id);

      this.Gear = this.OrderItems(this.Gear);

      await this.Change();
    }

    public async Task Unequip(ItemResponseModel item)
    {
      this.Gear.Remove(item);

      await this.gearsRepository.Unequip(item.Id);

      this.Gear = this.OrderItems(this.Gear);

      await this.Change();
    }

    private List<ItemResponseModel> OrderItems(List<ItemResponseModel> items)
    {
      var euquipetItems = items.Where(x => x.ItemType != "Empty").Count();

      if (euquipetItems == 0)
      {
        return items.Where(x => x.ItemType != "Empty").ToList();
      }

      var emptyItem = new ItemResponseModel();

      if (euquipetItems != 0 && items.Count > 9)
      {
        emptyItem = items.FirstOrDefault(x => x.ItemType == "Empty");

        items.Remove(emptyItem);
      }
      else
      {
        for (var i = 0; i < 9 - euquipetItems; i++)
        {
          items.Add(emptyItem);
        }
      }

      var gearItemsPosition = new List<string>()
      {
        "Empty", "Head", "Empty",
        "Sword", "Chest", "Shield",
        "Empty", "Boots", "Empty",
      };

      for (var i = 0; i < 9; i++)
      {
        var temp = items.FirstOrDefault(x => x.ItemType == gearItemsPosition[i]);

        if (temp == null)
        {
          continue;
        }

        var currItem = items.IndexOf(temp);
        items[currItem] = items[i];
        items[i] = temp;
      }

      return items;
    }

    private async Task Change()
      => await this.OnChange?.Invoke();
  }
}
