namespace SFMBE.Client.Pages.Character
{
  using System.Threading.Tasks;

  public partial class Gear
  {
    protected async override Task OnInitializedAsync()
    {
      this.GearState.OnChange += this.OnNotifyDataChanged;

      //await this.GearState.Initialize();
      await base.OnInitializedAsync();
    }

    private async Task OnNotifyDataChanged()
      => await this.InvokeAsync(this.StateHasChanged);
  }
}
