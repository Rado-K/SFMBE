namespace SFMBE.Client.Pages.Auth
{
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Infrastructure.Auth;
  using SFMBE.Client.Repositories.Accounts;
  using SFMBE.Shared;
  using SFMBE.Shared.Account;

  public partial class Login
  {
    private readonly UserLoginRequestModel userLoginRequestModel = new UserLoginRequestModel();

    private ApiResponse<UserLoginResponseModel> response;

    [Inject] public IAccountRepository AccountRepository { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public ILoginService LoginService { get; set; }

    private async Task Submit()
    {
      this.response = await this.AccountRepository.Login(userLoginRequestModel);

      if (this.response.IsOk)
      {
        await this.LoginService.Login(response.Data.Token);
        this.NavigationManager.NavigateTo("/");
      }
    }
  }
}