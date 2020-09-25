namespace SFMBE.Server.Repositories
{
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Identity;
  using SFMBE.Data.Models;
  using SFMBE.Shared.Authentication.Commands;

  public interface IUsersRepository
  {
    Task<ApplicationUser> GetUser();

    Task<IdentityResult> Register(RegisterParametersCommand parameters);
  }
}
