namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Shared.Items;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  public partial class ItemRow
  {
    [Parameter]
    public string Type { get; set; }

    [Parameter]
    public IList<ItemResponseModel> Items { get; set; }

    [Parameter]
    public string Border { get; set; } = "";

    private async Task OnNotifyDataChanged()
      => await this.InvokeAsync(this.StateHasChanged);
  }
}
