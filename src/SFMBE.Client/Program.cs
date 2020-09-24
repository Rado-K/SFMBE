namespace SFMBE.Client
{
  using System.Net.Http;
  using System.Reflection;
  using System.Threading.Tasks;
  using System;
  using BlazorState;
  using Microsoft.AspNetCore.Components.Authorization;
  using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using SFMBE.Client.Infrastructure.Authentication;
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Client.Infrastructure;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared;

  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("app");

      builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

      ConfigureServices(builder.Services);

      AutoMapperConfig.RegisterMappings(typeof(Error).GetTypeInfo().Assembly);
      await builder.Build().RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
      services.AddOptions();
      services.AddAuthorizationCore();

      services.AddSingleton<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
      services.AddSingleton<IAuthService, AuthService>();
      services.AddSingleton<IHttpService, HttpService>();

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