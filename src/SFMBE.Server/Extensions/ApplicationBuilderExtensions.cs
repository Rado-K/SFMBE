using Microsoft.AspNetCore.Builder;
using SFMBE.Server.Endpoints.Authentication.Common;

namespace SFMBE.Server.Extensions
{
  public static class ApplicationBuilderExtensions
  {
    public static void UseJwt(this IApplicationBuilder app)
    {
      app.UseMiddleware<JwtMiddleware>();
      app.UseAuthentication();
    }
  }
}