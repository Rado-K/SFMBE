namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Shared.Items;
  using System.Collections.Generic;

  public partial class Board
  {
    [Parameter]
    public string TypeBoard { get; set; }

    [Parameter]
    public int BoardRows { get; set; }

    [Parameter]
    public ItemsResponseModel Items { get; set; }

    private IList<ItemResponseModel> ItemsPerRow()
    {
      var rowCount = (this.Items.Items.Count < 3 ? this.Items.Items.Count : 3);
      var itemsPerRow = this.Items.Items.GetRange(0, rowCount);
      this.Items.Items.RemoveRange(0, rowCount);
      return itemsPerRow;
    }
  }
}
