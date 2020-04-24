using SFMBE.Data.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SFMBE.Services.Data.User
{
  public interface IUserService
  {
    Task<ApplicationUser> GetUser(params Expression<Func<ApplicationUser, object>>[] properties);
  }
}
