namespace SFMBE.Client
{
  using Blazor.Extensions.Logging;
  using Infrastructure;
  using Infrastructure.Auth;
  using Infrastructure.Http;
  using Microsoft.AspNetCore.Components.Authorization;
  using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Logging;
  using Respository.Accounts;
  using Respository.Bags;
  using Respository.Characters;
  using Respository.Gears;
  using Respository.Items;
  using Services.Mapping;
  using SFMBE.Shared;
  using State.Bag;
  using State.Gear;
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

      builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

      ConfigureServices(builder.Services);

      await builder.Build().RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
      services.AddLogging(builder => builder
        .AddBrowserConsole()
        .SetMinimumLevel(LogLevel.Debug));

      AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

      services.AddSingleton<JWTAuthenticationStateProvider>();
      services.AddSingleton<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());

      services.AddSingleton<ILoginService, JWTAuthenticationStateProvider>(
        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());

      services.AddSingleton<IApplicationState, ApplicationState>();
      services.AddSingleton<IHttpService, HttpService>();
      services.AddSingleton<IAccountRepository, AccountRepository>();
      services.AddSingleton<ICharactersRepository, CharactersRepository>();
      services.AddSingleton<IBagsRepository, BagsRepository>();
      services.AddSingleton<IItemsRepository, ItemsRepository>();
      services.AddSingleton<IGearsRepository, GearsRepository>();

      services.AddSingleton<BagState>();
      services.AddSingleton<GearState>();

      services.AddApiAuthorization();
    }
  }
}
