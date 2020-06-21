namespace SFMBE.Server.Controllers.User.Get
{
  using MediatR;
  using Microsoft.AspNetCore.Http;
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data;
  using SFMBE.Data.Models;
  using SFMBE.Shared.User.Get;
  using System;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetUserHandler : IRequestHandler<GetUserRequest, ApplicationUser>
  {
    private readonly ApplicationDbContext db;
    private readonly IHttpContextAccessor httpContext;

    public GetUserHandler(ApplicationDbContext db, IHttpContextAccessor httpContext)
    {
      this.db = db;
      this.httpContext = httpContext;
    }

    public async Task<ApplicationUser> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
      var user = await this.db
        .Users
        .Where(x => x.UserName == this.httpContext.HttpContext.User.Identity.Name)
        .FirstOrDefaultAsync();

      return user;
    }
  }
}
