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
    public IList<ItemResponseModel> Items { get; set; }

    [Parameter]
    public string Border { get; set; } = "";

    public EventCallback<int> Event { get; set; }

    protected override void OnInitialized()
    {
      this.Border = "row p-4 align-self-center " + this.Border;
    }

    private void Equip(int id)
    {
      this.Event.InvokeAsync(id);
    }
  }
}
