namespace SFMBE.Server.Endpoints.Authentication
{
  using System.Linq;
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Repositories;
  using SFMBE.Shared.Authentication.Commands;

  public class Register : BaseAsyncEndpoint
  {
    private readonly IUsersRepository usersRepository;

    public Register(IUsersRepository usersRepository)
    {
      this.usersRepository = usersRepository;
    }

    [HttpPost("api/Authorize/Register")]
    public async Task<IActionResult> HandleAsync([FromBody] RegisterParametersCommand parameters)
    {
      var result = await this.usersRepository.Register(parameters);

      if (!result.Succeeded)
      {
        return this.BadRequest(result.Errors.FirstOrDefault()?.Description);
      }

      return this.Ok(result.Succeeded);
    }
  }
}
