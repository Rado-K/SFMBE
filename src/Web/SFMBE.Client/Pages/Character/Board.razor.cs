namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Items;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public partial class Board
  {
    [Inject]
    public IItemsRepository ItemsRepository { get; set; }

    [Parameter]
    public string TypeBoard { get; set; }

    [Parameter]
    public int BoardRows { get; set; }

    [Parameter]
    public IList<int> Items { get; set; }

    private ApiResponse<ItemsResponseModel> items;

    protected override async Task OnInitializedAsync()
    {
      var requestModel = QueryableMappingExtensions.To<ItemsRequestModel>(this.Items);

      this.items = await this.ItemsRepository.GetItems(requestModel);

      if (this.items.Data != null)
      {
        if (this.TypeBoard == "gear" && this.items.Data.Items.Count < 9)
        {
          this.OrderItems();
        }

        if (this.BoardRows == 0)
        {
          this.BoardRows = (int)Math.Ceiling((decimal)(this.items.Data.Items.Count) / 3);
        }
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
        var currItem = this.items.Data.Items.IndexOf(temp);
        this.items.Data.Items[currItem] = this.items.Data.Items[i];
        this.items.Data.Items[i] = temp;
      }
    }

    private IList<ItemResponseModel> ItemsPerRow()
    {
      var rowCount = (this.items.Data.Items.Count < 3 ? this.items.Data.Items.Count : 3);
      var itemsPerRow = this.items.Data.Items.GetRange(0, rowCount);
      this.items.Data.Items.RemoveRange(0, rowCount);
      return itemsPerRow;
    }
  }
}
