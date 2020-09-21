namespace SFMBE.Client.Infrastructure.Authentication
{
  using Microsoft.AspNetCore.Components.Authorization;
  using Microsoft.JSInterop;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Security.Claims;
  using System.Text.Json;
  using System.Threading.Tasks;

  public class ApiAuthenticationStateProvider : AuthenticationStateProvider
  {
    private readonly HttpClient httpClient;
    private readonly IJSRuntime jsRuntime;

    public ApiAuthenticationStateProvider(HttpClient httpClient, IJSRuntime jsRuntime)
    {
      this.httpClient = httpClient;
      this.jsRuntime = jsRuntime;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      var savedToken = await this.jsRuntime.ReadToken();

      if (string.IsNullOrWhiteSpace(savedToken))
      {
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
      }

      httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);

      return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt")));
    }

    public void MarkUserAsAuthenticated(string email)
    {
      var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth"));
      var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
      NotifyAuthenticationStateChanged(authState);
    }

    public void MarkUserAsLoggedOut()
    {
      var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
      var authState = Task.FromResult(new AuthenticationState(anonymousUser));
      NotifyAuthenticationStateChanged(authState);
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
      var claims = new List<Claim>();
      var payload = jwt.Split('.')[1];
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
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
      base64 = base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
      return Convert.FromBase64String(base64);
    }
  }
}
