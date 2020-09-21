namespace SFMBE.Client.Shared
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Shared.Items.Queries;
  using System.Collections.Generic;

  public partial class Board
  {
    [Parameter]
    public string TypeBoard { get; set; }

    [Parameter]
    public int BoardRows { get; set; }

    [Parameter]
    public IList<GetItemQueryResponse> Items { get; set; }

    private IList<GetItemQueryResponse>[] ItemsPerRow()
    {
      var arr = new IList<GetItemQueryResponse>[this.BoardRows];

      var x = 0;

      for (var i = 0; i < this.BoardRows; i++)
      {
        arr[i] = new List<GetItemQueryResponse>();

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
