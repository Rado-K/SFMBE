namespace SFMBE.Client.Infrastructure.Authentication
{
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;
  using System;
  using Microsoft.JSInterop;
  using SFMBE.Client.Infrastructure.Common;
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared.Authentication.Commands;

  public class AuthService : IAuthService
  {
    private readonly IJSRuntime jsRuntime;
    private readonly IHttpService http;

    public AuthService(IHttpService http, IJSRuntime jsRuntime)
    {
      this.http = http;
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

      return response;
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
      base64 = base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
      return Convert.FromBase64String(base64);
    }

    public async Task Logout()
    {
      await this.jsRuntime.DeleteToken();
    }
  }
}