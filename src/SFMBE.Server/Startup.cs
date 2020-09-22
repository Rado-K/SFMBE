namespace SFMBE.Server
{
  using System.Reflection;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using Newtonsoft.Json;
  using SFMBE.Data;
  using SFMBE.Data.Models;
  using SFMBE.Data.Repositories;
  using SFMBE.Data.Seeding;
  using SFMBE.Server.Endpoints.Authentication.Common;
  using SFMBE.Server.Services;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared;

  public class Startup
  {
    private readonly IConfiguration configuration;

    public Startup(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                  options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
                  options.EnableSensitiveDataLogging();
                });

      services.AddControllers()
        .AddNewtonsoftJson(options
            => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

      services.AddIdentity<ApplicationUser, ApplicationRole>(IdentityOptionsProvider.GetIdentityOptions)
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();

      services.ConfigureJwt(this.configuration);

      services.AddHttpContextAccessor();

      services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

      services.AddScoped<IUsersService, UsersService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      AutoMapperConfig.RegisterMappings(typeof(Error).GetTypeInfo().Assembly);

      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (dbContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
        {
          dbContext.Database.Migrate();
        }

        new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
      }

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseWebAssemblyDebugging();
      }
      else
      {
        app.UseHsts();
        app.UseExceptionHandler("/Error");
      }

      app.UseHttpsRedirection();
      app.UseBlazorFrameworkFiles();
      app.UseStaticFiles();

      app.UseRouting();
      app.UseJwt();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapFallbackToFile("index.html");
      });
    }
  }
}