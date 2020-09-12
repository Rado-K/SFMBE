namespace SFMBE.Server.Endpoints.Authentication
{
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Services;
  using SFMBE.Shared.Authentication.Commands;

  public class Login : BaseAsyncEndpoint
  {
    private readonly IUsersService usersService;

    public Login(IUsersService usersService)
    {
      this.usersService = usersService;
    }

    [HttpPost("api/Authorize/Login")]
    public async Task<IActionResult> HandleAsync(LoginParametersCommand parameters)
    {
      var result = await this.usersService.Login(parameters);

      if (result != "You are login in")
      {
        return this.BadRequest(result);
      }

      return this.Ok(result);
    }
  }
}
