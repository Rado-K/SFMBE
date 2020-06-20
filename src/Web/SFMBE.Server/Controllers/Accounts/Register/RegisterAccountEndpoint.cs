namespace SFMBE.Server.Controllers.Accounts.Register
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared;
  using SFMBE.Shared.Account.Register;
  using System.Threading.Tasks;

  public class RegisterAccountEndpoint : BaseEndpoint<RegisterUserRequest, ApiResponse<RegisterUserResponse>>
  {
    [HttpPost(RegisterUserRequest.Route)]
    public async Task<IActionResult> Process([FromBody] RegisterUserRequest request)
      => await this.Send(request);
  }
}
