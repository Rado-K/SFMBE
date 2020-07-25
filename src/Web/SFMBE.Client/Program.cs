namespace SFMBE.Client
{
  using Blazor.Extensions.Logging;
  using BlazorState;
  using Infrastructure.Auth;
  using MediatR;
  using Microsoft.AspNetCore.Components.Authorization;
  using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Logging;
  using Services.Mapping;
  using SFMBE.Client.Features.EventStream;
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Client.Repositories.Accounts;
  using SFMBE.Client.Repositories.Characters;
  using SFMBE.Client.Repositories.Items;
  using SFMBE.Shared;
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
        .SetMinimumLevel(LogLevel.Error));

      AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

      services.AddSingleton<JWTAuthenticationStateProvider>();
      services.AddSingleton<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());

      services.AddSingleton<ILoginService, JWTAuthenticationStateProvider>(
        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());

      services.AddSingleton<IHttpService, HttpService>();
      services.AddSingleton<IAccountRepository, AccountRepository>();
      services.AddSingleton<ICharactersRepository, CharactersRepository>();
      services.AddSingleton<IItemsRepository, ItemsRepository>();

      services.AddBlazorState
      (
        (option) =>
        {
          option.UseReduxDevToolsBehavior = true;
          option.Assemblies =
          new[]
          {
            typeof(Program).GetTypeInfo().Assembly,
          };
        }
      );

      services.AddScoped(typeof(IPipelineBehavior<,>), typeof(EventStreamBehavior<,>));

      services.AddApiAuthorization();
    }
  }
}
