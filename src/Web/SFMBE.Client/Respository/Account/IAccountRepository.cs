namespace SFMBE.Client.Respository.Account
{
  using SFMBE.Shared;
  using SFMBE.Shared.Account;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public interface IAccountRepository
  {
    Task<ApiResponse<UserRegisterResponseModel>> Register(UserRegisterRequestModel userRegisterRequestModel);
    Task<ApiResponse<UserLoginResponseModel>> Login(UserLoginRequestModel userLoginRequestModel);
  }
}