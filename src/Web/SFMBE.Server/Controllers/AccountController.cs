namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Services.Data.Account;
  using SFMBE.Shared;
  using SFMBE.Shared.Account.Register;
  using System.Threading.Tasks;

  public class AccountController : BaseController
  {
    private readonly IAccountService accountService;

    public AccountController(
      IAccountService accountService)
    {
      this.accountService = accountService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<ApiResponse<RegisterUserResponse>>> Register([FromBody] RegisterUserRequest userRegisterRequestModel)
    {
      if (userRegisterRequestModel == null || !this.ModelState.IsValid)
      {
        return this.ModelStateErrors<RegisterUserResponse>();
      }

      var response = await this.accountService.Register(userRegisterRequestModel);

      if (response is null)
      {
        return this.BadRequest("Username or password invalid");
      }

      return this.Ok(response.ToApiResponse());
    }
  }
}