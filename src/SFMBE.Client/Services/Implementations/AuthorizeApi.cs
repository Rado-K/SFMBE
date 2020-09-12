namespace SFMBE.Client.Services.Implementations
{
  using System;
  using System.Net.Http;
  using System.Net.Http.Json;
  using System.Threading.Tasks;
  using SFMBE.Client.Services.Contracts;
  using SFMBE.Shared;
  using SFMBE.Shared.Authentication.Commands;

  public class AuthorizeApi : IAuthorizeApi
  {
    private readonly HttpClient httpClient;

    public AuthorizeApi(HttpClient httpClient)
    {
      this.httpClient = httpClient;
    }

    public async Task Login(LoginParametersCommand loginParameters)
    {
      var result = await this.httpClient.PostAsJsonAsync("api/Authorize/Login", loginParameters);
      if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
      {
        throw new Exception(await result.Content.ReadAsStringAsync());
      }

      result.EnsureSuccessStatusCode();
    }

    public async Task Logout()
    {
      var result = await this.httpClient.PostAsync("api/Authorize/Logout", null);
      result.EnsureSuccessStatusCode();
    }

    public async Task Register(RegisterParametersCommand registerParameters)
    {
      var result = await this.httpClient.PostAsJsonAsync("api/Authorize/Register", registerParameters);
      if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
      {
        throw new Exception(await result.Content.ReadAsStringAsync());
      }

      result.EnsureSuccessStatusCode();
    }

    public async Task<UserInfo> GetUserInfo()
    {
      var result = await this.httpClient.GetFromJsonAsync<UserInfo>("api/Authorize/UserInfo");
      return result;
    }
  }
}