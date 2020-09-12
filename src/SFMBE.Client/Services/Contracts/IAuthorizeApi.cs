namespace SFMBE.Client.Services.Contracts
{
  using System.Threading.Tasks;
  using SFMBE.Shared;
  using SFMBE.Shared.Authentication.Commands;

  public interface IAuthorizeApi
  {
    Task Login(LoginParametersCommand loginParameters);

    Task Register(RegisterParametersCommand registerParameters);

    Task Logout();

    Task<UserInfo> GetUserInfo();
  }
}