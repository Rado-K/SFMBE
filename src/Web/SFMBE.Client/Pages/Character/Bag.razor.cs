namespace SFMBE.Client.Pages.Character
{
  using System.Threading.Tasks;

  public partial class Bag
  {
    protected async override Task OnInitializedAsync()
    {
      this.BagState.OnChange += this.OnNotifyDataChanged;

      //await this.BagState.Initialize();
      await base.OnInitializedAsync();
    }

    private async Task OnNotifyDataChanged()
      => await this.InvokeAsync(this.StateHasChanged);
  }
}
