namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Bags;
  using SFMBE.Client.Respository.Items;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared;
  using SFMBE.Shared.Bags;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public partial class Bag
  {
    [Inject] public IBagsRepository BagsRepository { get; set; }

    [Inject] public IItemsRepository ItemsRepository { get; set; }

    private ApiResponse<BagResponseModel> bag;
    private ApiResponse<ItemsResponseModel> items;
    private int boardRows;

    protected async override Task OnInitializedAsync()
    {
      this.bag = await this.BagsRepository.GetBag();

      var requestModel = MappingExtensions.To<ItemsRequestModel>(this.bag.Data.Items);

      this.items = await this.ItemsRepository.GetItems(requestModel);

      if (this.items.Data != null)
      {
        this.boardRows = (int)Math.Ceiling((decimal)(this.items.Data.Items.Count) / 3);
      }
    }
  }
}
