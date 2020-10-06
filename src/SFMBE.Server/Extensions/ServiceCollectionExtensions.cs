namespace SFMBE.Server.Extensions
{
  using System.Text;
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.IdentityModel.Tokens;
  using SFMBE.Server.Endpoints.Authentication.Common;
  using SFMBE.Server.Repositories.Characters;
  using SFMBE.Server.Repositories.Items;
  using SFMBE.Server.Repositories;

  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddApplicationRepositories(this IServiceCollection services) => services
      .AddScoped<IUsersRepository, UsersRepository>()
      .AddTransient<ICharactersRepository, CharactersRepository>()
      .AddTransient<IItemsRepository, ItemsRepository>();

    public static void AddJwtConfigurations(this IServiceCollection services, IConfiguration configuration)
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

      // .AddAuthentication(JwtBearerDefaults.AuthenticationScheme) Not Working ;<
      services
        .AddAuthentication(options =>
        {
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
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