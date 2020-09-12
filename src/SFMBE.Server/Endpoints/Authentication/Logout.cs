namespace SFMBE.Server.Endpoints.Authentication
{
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Services;

  public class Logout : BaseAsyncEndpoint
  {
    private readonly IUsersService usersService;

    public Logout(IUsersService usersService)
    {
      this.usersService = usersService;
    }

    [Authorize]
    [HttpPost("api/Authorize/Logout")]
    public async Task<IActionResult> HandleAsync()
    {
      await this.usersService.Logout();
      return this.Ok();
    }
  }
}
