namespace SFMBE.Server
{
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

  public class Startup
  {
    private readonly IConfiguration configuration;

    public Startup(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                  options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
                  options.EnableSensitiveDataLogging();
                });

      services.ConfigureJwt(this.configuration);

      services.AddIdentity<ApplicationUser, ApplicationRole>(IdentityOptionsProvider.GetIdentityOptions)
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();

      services.AddControllers()
        .AddNewtonsoftJson(options
            => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

      services.AddHttpContextAccessor();

      services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

      services.AddScoped<IUsersService, UsersService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
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