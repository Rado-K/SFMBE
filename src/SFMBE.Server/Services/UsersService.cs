namespace SFMBE.Server.Services
{
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Identity;
  using SFMBE.Data.Models;
  using SFMBE.Shared.Authentication.Commands;

  public class UsersService : IUsersService
  {
    private readonly IHttpContextAccessor httpContext;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;

    public UsersService(
      IHttpContextAccessor httpContext,
      UserManager<ApplicationUser> userManager,
      SignInManager<ApplicationUser> signInManager)
    {
      this.httpContext = httpContext;
      this.userManager = userManager;
      this.signInManager = signInManager;
    }

    public async Task<IdentityResult> Register(RegisterParametersCommand parameters)
    {
      var user = new ApplicationUser
      {
        UserName = parameters.UserName
      };
      var result = await this.userManager.CreateAsync(user, parameters.Password);

      return result;
    }

    public async Task<string> Login(LoginParametersCommand loginParameters)
    {
      var user = await this.userManager.FindByNameAsync(loginParameters.UserName);
      if (user == null)
      {
        return "User does not exist";
      }

      var singInResult = await this.signInManager.CheckPasswordSignInAsync(user, loginParameters.Password, false);

      if (!singInResult.Succeeded)
      {
        return "Invalid password";
      }

      await this.signInManager.SignInAsync(user, loginParameters.RememberMe);

      return "You are login in";
    }

    public async Task Logout()
    {
      await this.signInManager.SignOutAsync();
    }

    public async Task<ApplicationUser> GetUser()
      => await this.userManager.GetUserAsync(this.httpContext.HttpContext.User);
  }
}
