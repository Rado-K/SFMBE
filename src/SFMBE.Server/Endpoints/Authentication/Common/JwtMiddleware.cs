namespace SFMBE.Server.Endpoints.Authentication.Common
{
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Options;
  using Microsoft.IdentityModel.Tokens;
  using Newtonsoft.Json;
  using SFMBE.Data.Models;
  using System;
  using System.Collections.Generic;
  using System.IdentityModel.Tokens.Jwt;
  using System.Linq;
  using System.Net;
  using System.Security.Claims;
  using System.Security.Principal;
  using System.Text;
  using System.Threading.Tasks;

  public class JwtMiddleware
  {
    private readonly RequestDelegate next;
    private readonly JwtOptions options;

    public JwtMiddleware(RequestDelegate next, IOptions<JwtOptions> options)
    {
      this.next = next;
      this.options = options.Value;
    }

    public Task Invoke(HttpContext context)
    {
      if (!context.Request.Path.Equals(this.options.Path, StringComparison.Ordinal))
      {
        return this.next(context);
      }

      if (context.Request.Method.Equals("POST") && context.Request.HasFormContentType)
      {
        return this.GenerateToken(context);
      }

      context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
      return context.Response.WriteAsync("Bad request");
    }

    private static int GetClaimIndex(IList<Claim> claims, string type)
    {
      for (var i = 0; i < claims.Count; i++)
      {
        if (claims[i].Type == type)
        {
          return i;
        }
      }

      return -1;
    }

    private async Task GenerateToken(HttpContext context)
    {
      var principal = await this.PrincipalResolver(context);
      if (principal == null)
      {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await context.Response.WriteAsync("Invalid email or password.");
        return;
      }

      var now = DateTime.UtcNow;
      var unixTimeSeconds = (long)Math.Round(
          (now.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

      var existingClaims = principal.Claims.ToList();

      var systemClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, principal.Identity.Name),
                new Claim(JwtRegisteredClaimNames.Jti, await this.options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64)
            };

      foreach (var systemClaim in systemClaims)
      {
        var existingClaimIndex = GetClaimIndex(existingClaims, systemClaim.Type);
        if (existingClaimIndex < 0)
        {
          existingClaims.Add(systemClaim);
        }
        else
        {
          existingClaims[existingClaimIndex] = systemClaim;
        }
      }

      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.options.SecretKey));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
      var jwt = new JwtSecurityToken(
          issuer: this.options.Issuer,
          audience: this.options.Audience,
          claims: existingClaims,
          notBefore: now,
          expires: now.Add(this.options.Expiration),
          signingCredentials: credentials);

      var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

      var response = new
      {
        token = encodedJwt,
        expires_in = (int)this.options.Expiration.TotalMilliseconds,
        roles = existingClaims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value)
      };

      context.Response.ContentType = "application/json";
      await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }

    private async Task<GenericPrincipal> PrincipalResolver(HttpContext context)
    {
      var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
      var email = context.Request.Form["email"];
      var user = await userManager.FindByEmailAsync(email);
      if (user == null || user.IsDeleted)
      {
        return null;
      }

      var password = context.Request.Form["password"];

      var isValidPassword = await userManager.CheckPasswordAsync(user, password);
      if (!isValidPassword)
      {
        return null;
      }

      var roles = await userManager.GetRolesAsync(user);

      var identity = new GenericIdentity(email, "Token");
      identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));

      return new GenericPrincipal(identity, roles.ToArray());
    }
  }
}

