namespace SFMBE.Client.Infrastructure.Auth
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Threading.Tasks;

  public interface ILoginService
  {
    Task Login(string token);

    Task Logout();
  }
}
