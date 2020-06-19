namespace SFMBE.Services.Data.Account
{
  using Microsoft.AspNetCore.Identity;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Bag;
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

    public async Task<RegisterUserResponse> Register(RegisterUserRequest userRegisterRequestModel)
    {
      var user = new ApplicationUser { UserName = userRegisterRequestModel.Email, Email = userRegisterRequestModel.Email};

      var result = await this.userManager.CreateAsync(user, userRegisterRequestModel.Password);

      if (!result.Succeeded)
      {
        return default;
      }

      return new RegisterUserResponse { Id = user.Id };
    }
  }
}
