namespace SFMBE.Client.Features.Items
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Shared.Items.Get;
  using System.Collections.Generic;

  public partial class ItemRow
  {
    [Parameter]
    public string Type { get; set; }

    [Parameter]
    public IList<GetItemResponse> Items { get; set; }

    [Parameter]
    public string Border { get; set; } = "";
  }
}
