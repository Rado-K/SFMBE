namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public partial class Board
  {
    [Parameter]
    public string TypeBoard { get; set; }

    [Parameter]
    public int BoardRows { get; set; } = 3;

    [Parameter]
    public List<ItemsBagResponseModel> Items { get; set; }

    private List<ItemsResponseModel> SendItems()
    {
      var rowCount = (this.Items.Count < 3 ? this.Items.Count : 3);
      Console.WriteLine(rowCount);
      //var rowItems = (int)(Math.Ceiling((decimal)(this.Items.Count) / rowCount));
      var items = this.Items.GetRange(0, rowCount);
      this.Items.RemoveRange(0, rowCount);

      return items;
    }
  }
}
