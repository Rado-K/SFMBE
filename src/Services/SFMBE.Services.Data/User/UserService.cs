namespace SFMBE.Services.Data.User
{
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Identity;
  using SFMBE.Data.Models;
  using System.Threading.Tasks;

  public class UserService : IUserService
  {
    private readonly IHttpContextAccessor httpContext;
    private readonly UserManager<ApplicationUser> userManager;

    public UserService(IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager)
    {
      this.httpContext = httpContext;
      this.userManager = userManager;
    }

    public string GetEmail()
      => this.httpContext.HttpContext.User?.Identity?.Name;

    public async Task<ApplicationUser> GetUser()
      => await this.userManager.GetUserAsync(this.httpContext.HttpContext.User);

    public async Task<bool> CurrentUserHasCharacter()
    {
      var user = await this.userManager.GetUserAsync(this.httpContext.HttpContext.User);

      return user.Character != null;
    }
  }
}
