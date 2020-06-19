namespace SFMBE.Client.Repositories.Accounts
{
  using SFMBE.Shared;
  using SFMBE.Shared.Account.Login;
  using SFMBE.Shared.Account.Register;
  using System.Threading.Tasks;

  public interface IAccountRepository
  {
    Task<ApiResponse<RegisterUserResponse>> Register(RegisterUserRequest userRegisterRequestModel);
    Task<ApiResponse<LoginUserResponse>> Login(LoginUserRequest userLoginRequestModel);
  }
}