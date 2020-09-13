namespace Tests.SFMBE.Server.UnitTests
{
  using global::SFMBE.Data;
  using global::SFMBE.Data.Seeding;
  using global::SFMBE.Server;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Mvc.Testing;
  using Microsoft.AspNetCore.TestHost;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Logging;
  using System;
  using System.Linq;

  public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
  {
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      builder
          .UseTestServer()
          //.UseSolutionRelativeContentRoot("sample/SampleEndpointApp")
          .ConfigureServices(services =>
          {
            var descriptor = services.SingleOrDefault(
            d => d.ServiceType ==
               typeof(DbContextOptions<ApplicationDbContext>));

            if (descriptor != null)
            {
              // remove default (real) implementation
              services.Remove(descriptor);
            }

            // Create a new service provider.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Add a database context (AppDbContext) using an in-memory
            // database for testing.
            services.AddDbContext<ApplicationDbContext>(options =>
            {
              options.UseInMemoryDatabase($"InMemoryDbForTesting");
              options.UseInternalServiceProvider(serviceProvider);
            });

            // Build the service provider.
            var sp = services.BuildServiceProvider();

            // Create a scope to obtain a reference to the database
            // context (AppDbContext).
            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();

            var logger = scopedServices
                      .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

            // Ensure the database is created.
            db.Database.EnsureCreated();

            //services.AddMvc(option =>
            //{
            //  option.Filters.Add(new AllowAnonymousFilter());
            //  option.Filters.Add(new FakeUserFilter());
            //});

            try
            {
              // Seed the database with test data.
              new ApplicationDbContextSeeder().SeedAsync(db, scopedServices).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
              logger.LogError(ex, "An error occurred seeding the " +
                        $"database with test messages. Error: {ex.Message}");
            }
          })
          .UseEnvironment("Test");
    }
  }
}