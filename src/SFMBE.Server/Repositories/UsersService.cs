namespace SFMBE.Server.Repositories
{
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Identity;
  using SFMBE.Data.Models;
  using SFMBE.Shared.Authentication.Commands;

  public class UsersRepository : IUsersRepository
  {
    private readonly IHttpContextAccessor httpContext;
    private readonly UserManager<ApplicationUser> userManager;

    public UsersRepository(
      IHttpContextAccessor httpContext,
      UserManager<ApplicationUser> userManager)
    {
      this.httpContext = httpContext;
      this.userManager = userManager;
    }

    public async Task<IdentityResult> Register(RegisterParametersCommand parameters)
    {
      var user = new ApplicationUser { UserName = parameters.Email, Email = parameters.Email };
      var result = await this.userManager.CreateAsync(user, parameters.Password);

      return result;
    }

    public async Task<ApplicationUser> GetUser()
      => await this.userManager.GetUserAsync(this.httpContext.HttpContext.User);
  }
}
