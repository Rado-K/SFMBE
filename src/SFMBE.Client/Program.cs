namespace SFMBE.Client
{
  using BlazorState;
  using Microsoft.AspNetCore.Components.Authorization;
  using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using SFMBE.Client.Infrastructure;
  using SFMBE.Client.Infrastructure.Authentication;
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Client.Infrastructure.State;
  using System;
  using System.Net.Http;
  using System.Reflection;
  using System.Threading.Tasks;

  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("app");

      builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

      ConfigureServices(builder.Services);

      await builder.Build().RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
      services.AddOptions();
      services.AddAuthorizationCore();
      services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
      services.AddScoped<IAuthService, AuthService>();
      services.AddSingleton<IHttpService, HttpService>();
      services.AddSingleton<IApplicationState, ApplicationState>();
      services.AddTransient<IApiClient, ApiClient>();

      services.AddBlazorState(option =>
      {
        option.UseReduxDevToolsBehavior = true;
        option.Assemblies = new []
        {
          typeof(Program).GetTypeInfo().Assembly,
        };
      });
    }
  }
}