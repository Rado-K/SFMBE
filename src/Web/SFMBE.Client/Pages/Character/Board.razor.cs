namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Items;
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
      var requestModel = new ItemsRequestModel { ItemsIds = Items };

      this.items = await this.ItemsRepository.GetItems(requestModel);

      if (this.TypeBoard == "gear" && this.items.Data.Items.Count < 9)
      {
        int emptyItemsCount = (9 - this.items.Data.Items.Count);
        for (int i = 0; i <= emptyItemsCount; i++)
        {
          this.items.Data.Items.Add(new ItemResponseModel());
        }
      }

      if (this.BoardRows == 0)
      {
        this.BoardRows = (int)Math.Ceiling((decimal)(this.items.Data.Items.Count) / 3);
      }
    }

    protected IList<ItemResponseModel> ItemsPerRow()
    {
      var rowCount = (this.items.Data.Items.Count < 3 ? this.items.Data.Items.Count : 3);
      //var rowItems = (int)(Math.Ceiling((decimal)(this.Items.Count) / rowCount));
      var itemsPerRow = this.items.Data.Items.GetRange(0, rowCount);
      this.items.Data.Items.RemoveRange(0, rowCount);
      return itemsPerRow;
    }
  }
}
