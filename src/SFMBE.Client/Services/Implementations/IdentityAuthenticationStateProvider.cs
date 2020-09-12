namespace SFMBE.Client.Services.Implementations
{
  using System;
  using System.Linq;
  using System.Net.Http;
  using System.Security.Claims;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Components.Authorization;
  using SFMBE.Client.Services.Contracts;
  using SFMBE.Shared;
  using SFMBE.Shared.Authentication.Commands;

  public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
  {
    private readonly IAuthorizeApi authorizeApi;
    private UserInfo userInfoCache;

    public IdentityAuthenticationStateProvider(IAuthorizeApi authorizeApi)
    {
      this.authorizeApi = authorizeApi;
    }

    public async Task Login(LoginParametersCommand loginParameters)
    {
      await this.authorizeApi.Login(loginParameters);
      this.NotifyAuthenticationStateChanged(this.GetAuthenticationStateAsync());
    }

    public async Task Register(RegisterParametersCommand registerParameters)
    {
      await this.authorizeApi.Register(registerParameters);
      this.NotifyAuthenticationStateChanged(this.GetAuthenticationStateAsync());
    }

    public async Task Logout()
    {
      await this.authorizeApi.Logout();
      this.userInfoCache = null;
      this.NotifyAuthenticationStateChanged(this.GetAuthenticationStateAsync());
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      var identity = new ClaimsIdentity();
      try
      {
        var userInfo = await this.GetUserInfo();
        if (userInfo.IsAuthenticated)
        {
          var claims = new[] { new Claim(ClaimTypes.Name, this.userInfoCache.Username) }
          .Concat(this.userInfoCache.ExposedClaims.Select(c => new Claim(c.Key, c.Value)));

          identity = new ClaimsIdentity(claims, "Server authentication");
        }
      }
      catch (HttpRequestException ex)
      {
        Console.WriteLine("Request failed:" + ex.ToString());
      }

      return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    private async Task<UserInfo> GetUserInfo()
    {
      if (this.userInfoCache != null && this.userInfoCache.IsAuthenticated)
      {
        return this.userInfoCache;
      }

      this.userInfoCache = await this.authorizeApi.GetUserInfo();
      return this.userInfoCache;
    }
  }
}