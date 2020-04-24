namespace SFMBE.Services.Data.User
{
  using Microsoft.AspNetCore.Http;
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using System;
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
      var user = await this.userRepository
        .GetWithProperties(
            x => x.UserName == this.httpContext.HttpContext.User.Identity.Name,
            properties)
        .FirstOrDefaultAsync();

      return user;
    }
  }
}
