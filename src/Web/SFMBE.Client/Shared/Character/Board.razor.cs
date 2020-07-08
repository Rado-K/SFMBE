namespace SFMBE.Client.Shared.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Shared.Items.Get;
  using System.Collections.Generic;

  public partial class Board
  {
    [Parameter]
    public string TypeBoard { get; set; }

    [Parameter]
    public int BoardRows { get; set; }

    [Parameter]
    public IList<GetItemResponse> Items { get; set; }

    private IList<GetItemResponse>[] ItemsPerRow()
    {
      var arr = new IList<GetItemResponse>[this.BoardRows];

      var x = 0;

      for (var i = 0; i < this.BoardRows; i++)
      {
        arr[i] = new List<GetItemResponse>();

        for (var j = 0; j < 3; j++)
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
