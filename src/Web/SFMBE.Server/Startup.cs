namespace SFMBE.Server
{
  using Common;
  using Data;
  using Data.Common;
  using Data.Common.Repositories;
  using Data.Models;
  using Data.Repositories;
  using MediatR;
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Diagnostics;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.ResponseCompression;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;
  using Microsoft.Extensions.Options;
  using Microsoft.IdentityModel.Tokens;

  using Newtonsoft.Json;
  using Services.Data.Account;
  using Services.Data.Items;
  using Services.Data.Storage;
  using Services.Mapping;
  using SFMBE.Services.Data.Character;
  using SFMBE.Services.Data.User;
  using SFMBE.Services.Data.Vendor;
  using SFMBE.Shared;
  using System;
  using System.Linq;
  using System.Net;
  using System.Reflection;
  using System.Security.Claims;
  using System.Security.Principal;
  using System.Text;
  using System.Threading.Tasks;
  using Web.Infrastructure.Middlewares.Authorization;

  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                  options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
                  options.EnableSensitiveDataLogging();
                });


      services
        .AddControllers()
        .AddNewtonsoftJson(options
            => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

      var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["JwtTokenValidation:Secret"]));
      services.Configure<TokenProviderOptions>(opts =>
      {
        opts.Audience = this.Configuration["JwtTokenValidation:Audience"];
        opts.Issuer = this.Configuration["JwtTokenValidation:Issuer"];
        opts.Path = "/api/account/login";
        opts.Expiration = TimeSpan.FromDays(15);
        opts.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
      });

      services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

      services
          .AddAuthentication(options =>
          {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
          })
          .AddJwtBearer(opts =>
          {
            opts.TokenValidationParameters = new TokenValidationParameters
            {
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = signingKey,
              ValidateIssuer = true,
              ValidIssuer = this.Configuration["JwtTokenValidation:Issuer"],
              ValidateAudience = true,
              ValidAudience = this.Configuration["JwtTokenValidation:Audience"],
              ValidateLifetime = true
            };
          });

      services.AddControllersWithViews();
      services.AddMvc();
      services.AddResponseCompression(opts =>
      {
        opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                  new[] { "application/octet-stream" });
      });

      services.AddSingleton(this.Configuration);

      services.AddScoped<IFileStorageService, StorageService>();
      services.AddHttpContextAccessor();
      services.AddMediatR(typeof(Startup));

      // Data repositories
      services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
      services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
      services.AddScoped<IDbQueryRunner, DbQueryRunner>();

      // Application services
      services.AddScoped<IAccountService, AccountService>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<ICharactersService, CharactersService>();
      services.AddScoped<IItemsService, ItemsService>();
      services.AddScoped<IVendorService, VendorService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

      app.UseResponseCompression();

      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (env.IsDevelopment())
        {
          dbContext.Database.Migrate();
        }
      }

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseWebAssemblyDebugging();
      }
      else
      {
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseExceptionHandler("/Error");
      }

      app.UseExceptionHandler(this.ExceptionHandler(env));

      app.UseJwtBearerTokens(
                app.ApplicationServices.GetRequiredService<IOptions<TokenProviderOptions>>(),
                this.PrincipalResolver);

      app.UseBlazorFrameworkFiles();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapFallbackToFile("index.html");
      });
    }

    private Action<IApplicationBuilder> ExceptionHandler(IWebHostEnvironment env) => alternativeApp =>
    {
      alternativeApp.Run(
          async context =>
          {
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = GlobalConstants.JsonContentType;
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandlerFeature?.Error != null)
            {
              var ex = exceptionHandlerFeature.Error;
              while (ex is AggregateException aggregateException
                       && aggregateException.InnerExceptions.Any())
              {
                ex = aggregateException.InnerExceptions.First();
              }

              //// TODO: Log it

              var exceptionMessage = ex.Message;
              if (env.IsDevelopment())
              {
                exceptionMessage = ex.ToString();
              }

              await context.Response
                    .WriteAsync(JsonConvert.SerializeObject(new ApiResponse<object>(new ApiError("GLOBAL", exceptionMessage))))
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
          });
    };

    private async Task<GenericPrincipal> PrincipalResolver(HttpContext context)
    {
      var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
      var email = context.Request.Form["email"];
      var user = await userManager.FindByEmailAsync(email);
      if (user == null || user.IsDeleted)
      {
        return null;
      }

      var password = context.Request.Form["password"];

      var isValidPassword = await userManager.CheckPasswordAsync(user, password);
      if (!isValidPassword)
      {
        return null;
      }

      var roles = await userManager.GetRolesAsync(user);

      var identity = new GenericIdentity(email, "Token");
      identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));

      return new GenericPrincipal(identity, roles.ToArray());
    }
  }
}
