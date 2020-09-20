namespace Integration.Tests
{
  using System;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Mvc.Testing;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.DependencyInjection.Extensions;
  using SFMBE.Data;
  using SFMBE.Server;
  
  public class IntegrationTestFactory : WebApplicationFactory<Startup>
  {
    protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                 services.AddEntityFrameworkInMemoryDatabase();

                // Create a new service provider.
                var provider = services
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (ApplicationDbContext) using an in-memory 
                // database for testing.
                // services.AddDbContext<CatalogContext>(options =>
                // {
                //     options.UseInMemoryDatabase("InMemoryDbForTesting");
                //     options.UseInternalServiceProvider(provider);
                // });

                // services.AddDbContext<AppIdentityDbContext>(options =>
                // {
                //     options.UseInMemoryDatabase("Identity");
                //     options.UseInternalServiceProvider(provider);
                // });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<CatalogContext>();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();

                }
            });
        }
    protected async Task AuthenticationAsync()
    {
      // this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await this.GetJwtAsync());
    }

    private async Task<string> GetJwtAsync()
    {
      throw new NotImplementedException();
    }
  }
}