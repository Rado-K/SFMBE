namespace SFMBE.Services
{
  using Microsoft.AspNetCore.Identity;
  using Microsoft.Extensions.Configuration;
  using Microsoft.IdentityModel.Tokens;
  using SFMBE.Data.Models;
  using SFMBE.Shared.Account;
  using System;
  using System.Collections.Generic;
  using System.IdentityModel.Tokens.Jwt;
  using System.Security.Claims;
  using System.Text;
  using System.Threading.Tasks;

  public class AccountService : IAccountService
  {
    private readonly UserManager<ApplicationUser> userManager;

    public AccountService(UserManager<ApplicationUser> userManager)
    {
      this.userManager = userManager;
    }

    public async Task<UserRegisterResponseModel> Register(UserRegisterRequestModel userRegisterRequestModel)
    {
      var user = new ApplicationUser { UserName = userRegisterRequestModel.Email, Email = userRegisterRequestModel.Email };
      var result = await this.userManager.CreateAsync(user, userRegisterRequestModel.Password);

      if (!result.Succeeded)
      {
        return default;
      }

      return new UserRegisterResponseModel { Id = user.Id };
    }
  }
}
