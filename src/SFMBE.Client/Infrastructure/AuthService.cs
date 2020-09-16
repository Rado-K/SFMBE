namespace SFMBE.Client.Infrastructure
{
  using Microsoft.AspNetCore.Components.Authorization;
  using Microsoft.JSInterop;
  using SFMBE.Shared;
  using SFMBE.Shared.Authentication.Commands;
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;

  public class AuthService : IAuthService
  {
    private readonly AuthenticationStateProvider authenticationStateProvider;
    private readonly IJSRuntime jsRuntime;
    private readonly IHttpService http;

    public AuthService(IHttpService http,
                       AuthenticationStateProvider authenticationStateProvider,
                       IJSRuntime jsRuntime)
    {
      this.http = http;
      this.authenticationStateProvider = authenticationStateProvider;
      this.jsRuntime = jsRuntime;
    }

    public async Task<ApiResponse<bool>> Register(RegisterParametersCommand registerParametersCommandResponse)
    {
      var result = await this.http.PostJson<RegisterParametersCommand, bool>("api/Authorize/Register", registerParametersCommandResponse);

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

      var response = await this.http.PostJson<FormUrlEncodedContent, LoginParametersCommandResponse>("api/Authorize/Login", request);

      await this.jsRuntime.SaveToken(response.Data.token);
      ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(loginParametersCommand.Email);

      return response;
    }

    public async Task Logout()
    {
      await jsRuntime.DeleteToken();
      ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();
    }
  }
}
