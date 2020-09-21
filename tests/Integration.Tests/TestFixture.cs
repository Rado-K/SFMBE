namespace Integration.Tests
{
  using System.Threading.Tasks;
  using System;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Mvc.Testing;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.DependencyInjection;
  using SFMBE.Data.Seeding;
  using SFMBE.Data;
  using SFMBE.Server;

  public class TestFixture : WebApplicationFactory<Startup>
  {
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      builder.UseEnvironment("Test");

      builder.ConfigureServices(services =>
      {
        services.AddEntityFrameworkInMemoryDatabase();

        // Create a new service provider.
        var provider = services
          .AddEntityFrameworkInMemoryDatabase()
          .BuildServiceProvider();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
          options.UseInMemoryDatabase("InMemoryDbTesting");
          options.UseInternalServiceProvider(provider);
        });

        // Build the service provider.
        var sp = services.BuildServiceProvider();

        // Create a scope to obtain a reference to the database
        // context (ApplicationDbContext).
        using(var serviceScope = sp.CreateScope())
        {
          var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

          if (dbContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
          {
            dbContext.Database.Migrate();
          }

          new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
        }
      });
    }
    protected async Task AuthenticationAsync()
    {
      //this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await this.GetJwtAsync());
    }

    private async Task<string> GetJwtAsync()
    {

      throw new NotImplementedException();
    }
  }
}
