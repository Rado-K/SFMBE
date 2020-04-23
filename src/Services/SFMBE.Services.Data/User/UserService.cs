namespace SFMBE.Services.Data.User
{
  using Microsoft.AspNetCore.Http;
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using System;
  using System.Linq;
  using System.Linq.Expressions;
  using System.Threading.Tasks;

  public class UserService : IUserService
  {
    private readonly IHttpContextAccessor httpContext;
    private readonly IRepository<ApplicationUser> userRepository;

    public UserService(
      IHttpContextAccessor httpContext,
      IRepository<ApplicationUser> userRepository)
    {
      this.httpContext = httpContext;
      this.userRepository = userRepository;
    }

    public async Task<ApplicationUser> GetUser(params Expression<Func<ApplicationUser, object>>[] properties)
    {
      ApplicationUser user = default;

      if (properties is null)
      {
        user = await this.userRepository
          .AllAsNoTracking()
          .Where(x => x.UserName == this.httpContext.HttpContext.User.Identity.Name)
          .FirstOrDefaultAsync();
      }
      else
      {
        user = this.userRepository
        .GetWithProperties(
        x => x.UserName == this.httpContext.HttpContext.User.Identity.Name,
        properties)
        .FirstOrDefault();
      }

      return user;
    }
  }
}
