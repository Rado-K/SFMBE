namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Gears;
  using SFMBE.Client.Respository.Items;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared;
  using SFMBE.Shared.Gear;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public partial class Gear
  {
    [Inject] public IGearsRepository GearsRepository { get; set; }
    [Inject] public IItemsRepository ItemsRepository { get; set; }

    private ApiResponse<GearResponseModel> gear;
    private ApiResponse<ItemsResponseModel> items;

    protected async override Task OnInitializedAsync()
    {
      this.gear = await this.GearsRepository.GetGear();

      var requestModel = MappingExtensions.To<ItemsRequestModel>(this.gear.Data.Items);

      this.items = await this.ItemsRepository.GetItems(requestModel);

      if (this.items.Data != null)
      {
        this.OrderItems();
      }
    }

    private void OrderItems()
    {
      int emptyItemsCount = (9 - this.items.Data.Items.Count);
      for (int i = 0; i <= emptyItemsCount; i++)
      {
        this.items.Data.Items.Add(new ItemResponseModel());
      }

      var gearItemsPosition = new List<string>()
      {
        "Empty", "Head", "Empty",
        "Sword", "Chest", "Shield",
        "Empty", "Boots", "Empty",
      };

      for (int i = 0; i < 9; i++)
      {
        var temp = this.items.Data.Items.FirstOrDefault(x => x.ItemType == gearItemsPosition[i]);

        if (temp is null)
        {
          continue;
        }

        var currItem = this.items.Data.Items.IndexOf(temp);
        this.items.Data.Items[currItem] = this.items.Data.Items[i];
        this.items.Data.Items[i] = temp;
      }
    }
  }
}
