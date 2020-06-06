namespace SFMBE.Client.Store.Bag
{
  using Microsoft.Extensions.Logging;
  using SFMBE.Client.Respository.Bags;
  using SFMBE.Client.Respository.Items;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  public partial class BagState
  {
    private readonly IBagsRepository bagsRepository;
    private readonly IItemsRepository itemsRepository;

    public BagState(IBagsRepository bagsRepository, IItemsRepository itemsRepository)
    {
      this.bagsRepository = bagsRepository;
      this.itemsRepository = itemsRepository;
    }

    public event Func<Task> OnChange;

    public List<ItemResponseModel> Bag { get; set; }

    public int BoardRows
      => this.Bag is null
        ? 0 : (int)Math.Ceiling((decimal)(this.Bag.Count) / 3);

    public async Task Initialize()
    {
      var bag = await this.bagsRepository.GetBag();
      var requestModel = bag.Data.Items.To<ItemsRequestModel>();

      this.Bag = (await this.itemsRepository.GetItems(requestModel)).Data.Items;
    }

    public async Task Equip(ItemResponseModel item)
    {
      this.Bag.Add(item);
      await this.Change();
    }

    public async Task Unequip(ItemResponseModel item)
    {
      this.Bag.Remove(item);
      await this.Change();
    }

    private async Task Change()
      => await this.OnChange?.Invoke();
  }
}
