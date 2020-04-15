namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public partial class ItemRow
  {
    [Parameter]
    public string Type { get; set; }

    [Parameter]
    public List<ItemsBagResponseModel> Items { get; set; }

    [Parameter]
    public string Border { get; set; } = "";

    protected override void OnInitialized()
    {
      this.Border = "row p-4 align-self-center " + this.Border;
    }

    //private bool AllowDrag(Item item)
    //{
    //    item.ClassName = this.Type == "bag" ? "" : "border";

    //    return default;
    //}
  }
}
