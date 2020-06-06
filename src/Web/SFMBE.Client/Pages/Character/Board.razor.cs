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
    public List<ItemResponseModel> Items { get; set; }

    private IList<ItemResponseModel>[] ItemsPerRow()
    {
      var arr = new IList<ItemResponseModel>[this.BoardRows];

      int x = 0;

      for (int i = 0; i < this.BoardRows; i++)
      {
        arr[i] = new List<ItemResponseModel>();

        for (int j = 0; j < 3; j++)
        {
          if (x == this.Items.Count)
          {
            break;
          }

          arr[i].Add(this.Items[x++]);
        }
      }

      return arr;
    }
  }
}
