namespace SFMBE.Client.Infrastructure.Authentication
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Net.Http.Headers;
  using System.Net.Http;
  using System.Security.Claims;
  using System.Text.Json;
  using System.Threading.Tasks;
  using System;
  using Microsoft.AspNetCore.Components.Authorization;
  using Microsoft.JSInterop;
  using SFMBE.Client.Infrastructure.Http;

  public class ApiAuthenticationStateProvider : AuthenticationStateProvider
  {
    private readonly IHttpService httpService;
    private readonly IJSRuntime jsRuntime;
    private readonly AuthenticationState anonymous;

    public ApiAuthenticationStateProvider(IHttpService httpService, IJSRuntime jsRuntime)
    {
      this.httpService = httpService;
      this.jsRuntime = jsRuntime;
      this.anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      var savedToken = await this.jsRuntime.ReadToken();

      if (string.IsNullOrWhiteSpace(savedToken))
      {
        return this.anonymous;
      }

      this.httpService.SetAuthorization(new AuthenticationHeaderValue("Bearer", savedToken));

      var state = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt")));
      return state;
    }

    public async Task MarkUserAsAuthenticated() => this.ChangeAuthenticationState(await this.GetAuthenticationStateAsync());

    public void MarkUserAsLoggedOut() => this.ChangeAuthenticationState(this.anonymous);

    private void ChangeAuthenticationState(AuthenticationState state) => this.NotifyAuthenticationStateChanged(Task.FromResult(state));

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
      var claims = new List<Claim>();
      var payload = jwt.Split('.') [1];
      var jsonBytes = ParseBase64WithoutPadding(payload);
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

      byte[] ParseBase64WithoutPadding(string base64)
      {
        base64 = base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
        return Convert.FromBase64String(base64);
      }
    }
  }
}