namespace SFMBE.Client
{
  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using System.Text;
  using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using SFMBE.Client.Infrastructure.Auth;
  using Microsoft.AspNetCore.Components.Authorization;
  using SFMBE.Client.Infrastructure;
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Client.Respository.Account;

  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("app");

      ConfigureServices(builder.Services);

      await builder.Build().RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
      services.AddOptions();

      services.AddScoped<JWTAuthenticationStateProvider>();
      services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());

      services.AddScoped<ILoginService, JWTAuthenticationStateProvider>(
        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());


      services.AddSingleton<IApplicationState, ApplicationState>();
      services.AddScoped<IHttpService, HttpService>();
      services.AddScoped<IAccountRepository, AccountRepository>();
      //services.AddTransient<IApiClient, ApiClient>();

      services.AddApiAuthorization();
      services.AddBaseAddressHttpClient();
    }
  }
}
