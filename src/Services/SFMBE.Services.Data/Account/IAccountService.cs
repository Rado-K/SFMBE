namespace SFMBE.Services.Data.Account
{
  using SFMBE.Shared.Account;
  using System.Threading.Tasks;

  public interface IAccountService
  {
    Task<UserRegisterResponseModel> Register(UserRegisterRequestModel userRegisterRequestModel);
  }
}
