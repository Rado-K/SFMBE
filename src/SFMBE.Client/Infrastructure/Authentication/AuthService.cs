namespace SFMBE.Client.Infrastructure.Authentication
{
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;
  using Microsoft.JSInterop;
  using SFMBE.Client.Infrastructure.Common;
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared.Authentication.Commands;
  using Microsoft.AspNetCore.Components.Authorization;

  public class AuthService : IAuthService
  {
    private readonly IJSRuntime jsRuntime;
    private readonly ApiAuthenticationStateProvider apiAuthenticationStateProvider;
    private readonly IHttpService httpService;

    public AuthService(IHttpService httpService, IJSRuntime jsRuntime, AuthenticationStateProvider authenticationStateProvider)
    {
      this.httpService = httpService;
      this.jsRuntime = jsRuntime;
      this.apiAuthenticationStateProvider = authenticationStateProvider as ApiAuthenticationStateProvider;
    }

    public async Task<ApiResponse<bool>> Register(RegisterParametersCommand registerParametersCommandResponse)
    {
      var result = await this.httpService.PostJson<RegisterParametersCommand, bool>("api/Authorize/Register", registerParametersCommandResponse);

      return result;
    }

    public async Task<ApiResponse<LoginParametersCommandResponse>> Login(LoginParametersCommand loginParametersCommand)
    {
      var request = new FormUrlEncodedContent(
        new List<KeyValuePair<string, string>>
        {
          new KeyValuePair<string, string>("email", loginParametersCommand.Email),
          new KeyValuePair<string, string>("password", loginParametersCommand.Password),
        });

      var response = await this.httpService.PostJson<FormUrlEncodedContent, LoginParametersCommandResponse>("api/Authorize/Login", request);

      await this.jsRuntime.SaveToken(response.Data.token);

      await this.apiAuthenticationStateProvider.MarkUserAsAuthenticated();
      return response;
    }

    public async Task Logout()
    {
      await this.jsRuntime.DeleteToken();
      this.apiAuthenticationStateProvider.MarkUserAsLoggedOut();
    }
  }
}