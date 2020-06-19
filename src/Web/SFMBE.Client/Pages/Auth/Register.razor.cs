namespace SFMBE.Client.Pages.Auth
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Infrastructure.Auth;
  using SFMBE.Client.Repositories.Accounts;
  using SFMBE.Shared;
  using SFMBE.Shared.Account.Register;
  using System.Threading.Tasks;

  public partial class Register
  {
    private readonly RegisterUserRequest userLoginRequestModel = new RegisterUserRequest();

    private ApiResponse<RegisterUserResponse> response;

    [Inject] public IAccountRepository AccountRepository { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public ILoginService LoginService { get; set; }

    private async Task CreateUser()
    {
      this.response = await this.AccountRepository.Register(this.userLoginRequestModel);

      if (this.response.IsOk)
      {
        this.NavigationManager.NavigateTo("/login");
      }
    }
  }
}