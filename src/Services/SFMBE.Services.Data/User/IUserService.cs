using SFMBE.Data.Models;
using System.Threading.Tasks;

namespace SFMBE.Services.Data.User
{
  public interface IUserService
  {
    Task<ApplicationUser> GetUser();
    string GetEmail();
  }
}
