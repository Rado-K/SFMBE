namespace SFMBE.Server.Controllers.Accounts.Register
{
  using MediatR;
  using Microsoft.AspNetCore.Identity;
  using SFMBE.Data.Models;
  using SFMBE.Shared;
  using SFMBE.Shared.Account.Register;
  using System.Threading;
  using System.Threading.Tasks;

  public class RegisterAccountHandler : IRequestHandler<RegisterUserRequest, ApiResponse<RegisterUserResponse>>
  {
    private readonly UserManager<ApplicationUser> userManager;

    public RegisterAccountHandler(
      UserManager<ApplicationUser> userManager)
    {
      this.userManager = userManager;
    }

    public async Task<ApiResponse<RegisterUserResponse>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
      var user = new ApplicationUser { UserName = request.Email, Email = request.Email };

      var result = await this.userManager.CreateAsync(user, request.Password);

      if (!result.Succeeded)
      {
        return default;
      }

      return new RegisterUserResponse { Id = user.Id }.ToApiResponse();
    }
  }
}
