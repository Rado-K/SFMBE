namespace SFMBE.Services
{
  using SFMBE.Shared.Account;
  using System.Threading.Tasks;

  public interface IAccountService
  {
    //Task<UserLoginResponseModel> Login(UserLoginRequestModel userLoginRequestModel);
    Task<UserRegisterResponseModel> Register(UserRegisterRequestModel userRegisterRequestModel);
  }
}
