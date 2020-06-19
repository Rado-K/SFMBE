namespace SFMBE.Services.Data.Account
{
  using SFMBE.Shared.Account.Register;
  using System.Threading.Tasks;

  public interface IAccountService
  {
    Task<RegisterUserResponse> Register(RegisterUserRequest userRegisterRequestModel);
  }
}
