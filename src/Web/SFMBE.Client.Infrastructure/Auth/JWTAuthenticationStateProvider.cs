namespace SFMBE.Client.Infrastructure.Auth
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Security.Claims;
  using System.Text.Json;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Components.Authorization;
  using Microsoft.JSInterop;

  public class JWTAuthenticationStateProvider : AuthenticationStateProvider, ILoginService
  {
    private readonly IJSRuntime js;
    private readonly HttpClient httpClient;
    private readonly AuthenticationState anonymous;

    public JWTAuthenticationStateProvider(IJSRuntime js, HttpClient httpClient)
    {
      this.js = js;
      this.httpClient = httpClient;
      this.anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      var token = await this.js.ReadToken();

      if (string.IsNullOrEmpty(token))
      {
        return this.anonymous;
      }

      return this.BuildAuthenticationState(token);
    }

    public async Task Login(string token)
    {
      await this.js.SaveToken(token);
      var authState = this.BuildAuthenticationState(token);
      this.StateChanged(authState);
    }

    public async Task Logout()
    {
      await this.js.DeleteToken();
      await this.js.StorageDelete("sessionId");
      this.httpClient.DefaultRequestHeaders.Authorization = default;
      this.StateChanged(this.anonymous);
    }

    private AuthenticationState BuildAuthenticationState(string token)
    {
      this.httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("bearer", token);

      return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(this.ParseClaimsFromJwt(token), "jwt")));
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
      var claims = new List<Claim>();
      var payload = jwt.Split('.')[1];
      var jsonBytes = this.ParseBase64WithoutPadding(payload);
      var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

      keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

      if (roles != null)
      {
        if (roles.ToString().Trim().StartsWith("["))
        {
          var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

          foreach (var parsedRole in parsedRoles)
          {
            claims.Add(new Claim(ClaimTypes.Role, parsedRole));
          }
        }
        else
        {
          claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
        }

        keyValuePairs.Remove(ClaimTypes.Role);
      }

      claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
      return claims;
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
      base64 = base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
      return Convert.FromBase64String(base64);
    }

    private void StateChanged(AuthenticationState state)
      => this.NotifyAuthenticationStateChanged(Task.FromResult(state));
  }
}
