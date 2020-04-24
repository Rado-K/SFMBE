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
  using SFMBE.Client.Respository.Accounts;
  using SFMBE.Client.Respository.Characters;
  using SFMBE.Client.Respository.Bags;
  using SFMBE.Client.Pages.Character;
  using SFMBE.Client.Respository.Items;
  using System.Net.Http;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared;
  using System.Reflection;

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
      //services.AddOptions();
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


      services.AddApiAuthorization();
    }
  }
}
