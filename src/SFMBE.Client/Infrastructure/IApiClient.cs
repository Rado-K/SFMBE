namespace SFMBE.Client.Infrastructure
{
  using System.Threading.Tasks;
  using SFMBE.Client.Infrastructure.Common;
  using SFMBE.Shared.Authentication.Commands;

  public interface IApiClient
  {
    Task<ApiResponse<LoginParametersCommandResponse>> UserLogin(LoginParametersCommand request);
    Task<ApiResponse<RegisterParametersCommandResponse>> UserRegister(RegisterParametersCommand request);
  }
}
