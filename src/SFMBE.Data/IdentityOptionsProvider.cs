namespace SFMBE.Data
{
  using Microsoft.AspNetCore.Identity;

  public class IdentityOptionsProvider
  {
    public static void GetIdentityOptions(IdentityOptions options)
    {
      // Password settings
      options.Password.RequireDigit = false;
      options.Password.RequiredLength = 6;
      options.Password.RequireNonAlphanumeric = false;
      options.Password.RequireUppercase = false;
      options.Password.RequireLowercase = false;
      ////options.Password.RequiredUniqueChars = 6;

      // Lockout settings
      options.Lockout.MaxFailedAccessAttempts = 1000;
      options.Lockout.AllowedForNewUsers = true;

      // User settings
      options.User.RequireUniqueEmail = false;
    }
  }
}
