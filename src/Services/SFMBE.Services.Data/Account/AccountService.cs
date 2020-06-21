namespace SFMBE.Services.Data.Account
{
  using Microsoft.AspNetCore.Identity;
  using SFMBE.Data.Models;
  using SFMBE.Shared.Account.Register;
  using System.Threading.Tasks;

  public class AccountService : IAccountService
  {
    private readonly UserManager<ApplicationUser> userManager;

    public AccountService(
      UserManager<ApplicationUser> userManager)
    {
      this.userManager = userManager;
    }

    public async Task<RegisterUserResponse> Register(RegisterUserRequest registerUserRequest)
    {
      var user = new ApplicationUser { UserName = registerUserRequest.Email, Email = registerUserRequest.Email };

      var result = await this.userManager.CreateAsync(user, registerUserRequest.Password);

      if (!result.Succeeded)
      {
        return default;
      }

      return new RegisterUserResponse { Id = user.Id };
    }
  }
}
