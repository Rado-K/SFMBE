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

    public UsersService(
      IHttpContextAccessor httpContext,
      UserManager<ApplicationUser> userManager)
    {
      this.httpContext = httpContext;
      this.userManager = userManager;
    }

    public async Task<IdentityResult> Register(RegisterParametersCommand parameters)
    {
      var user = new ApplicationUser
      {
        Email = parameters.UserName
      };
      var result = await this.userManager.CreateAsync(user, parameters.Password);

      return result;
    }

    public async Task<ApplicationUser> GetUser()
      => await this.userManager.GetUserAsync(this.httpContext.HttpContext.User);
  }
}
