namespace SFMBE.Client.Infrastructure
{
  using SFMBE.Shared;
  using SFMBE.Shared.Authentication.Commands;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public interface IAuthService
  {
    Task<ApiResponse<LoginParametersCommandResponse>> Login(LoginParametersCommand loginParametersCommand);
    Task Logout();
    Task<ApiResponse<RegisterParametersCommandResponse>> Register(RegisterParametersCommand registerParametersCommandResponse);
  }
}
