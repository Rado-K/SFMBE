namespace SFMBE.Client.Infrastructure
{
  using SFMBE.Shared;
  using SFMBE.Shared.Authentication.Commands;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public interface IApiClient
  {
    Task<ApiResponse<LoginParametersCommandResponse>> UserLogin(LoginParametersCommand request);
    Task<ApiResponse<RegisterParametersCommandResponse>> UserRegister(RegisterParametersCommand request);
  }
}
