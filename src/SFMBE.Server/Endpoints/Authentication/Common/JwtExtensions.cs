namespace SFMBE.Server.Endpoints.Authentication.Common
{
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.IdentityModel.Tokens;
  using System.Text;

  public static class JwtExtensions
  {
    public static void UseJwt(this IApplicationBuilder app)
    {
      app.UseMiddleware<JwtMiddleware>();
      app.UseAuthentication();
    }

    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
      var issuer = configuration["JwtValidation:Issuer"];
      var audience = configuration["JwtValidation:Audience"];
      var key = configuration["JwtValidation:SecretKey"];
      var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
      services.Configure<JwtOptions>(options =>
      {
        options.Path = "/api/Authorize/Login";
        options.Issuer = issuer;
        options.Audience = audience;
        options.SecretKey = key;
      });

      services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.RequireHttpsMetadata = false;
          options.SaveToken = true;
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
          };
        });
    }
  }
}
