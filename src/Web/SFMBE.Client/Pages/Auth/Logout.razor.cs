namespace SFMBE.Client.Pages.Auth
{
  using BlazorState;
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Infrastructure.Auth;
  using System.Threading.Tasks;

  public partial class Logout
  {
    [Inject] public ILoginService LoginService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IStore Store { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await this.LoginService.Logout();
      this.Store.Reset();
      this.NavigationManager.NavigateTo("");
    }
  }
}
