namespace SFMBE.Client.Infrastructure.Authentication
{
  using SFMBE.Client.Infrastructure.Common;
  using SFMBE.Shared.Authentication.Commands;
  using System.Threading.Tasks;

  public interface IAuthService
  {
    Task<ApiResponse<LoginParametersCommandResponse>> Login(LoginParametersCommand loginParametersCommand);

    Task Logout();

    Task<ApiResponse<bool>> Register(RegisterParametersCommand registerParametersCommandResponse);
  }
}
