namespace SFMBE.Client.Repositories.Accounts
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Account.Login;
  using SFMBE.Shared.Account.Register;
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading.Tasks;

  public class AccountRepository : IAccountRepository
  {
    private const string URL = "api/account";
    private readonly IHttpService httpService;

    public AccountRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<ApiResponse<RegisterUserResponse>> Register(RegisterUserRequest userRegisterRequestModel)
    {
      var httpResponse = await this.httpService.PostJson<RegisterUserRequest, RegisterUserResponse>($"{URL}/register", userRegisterRequestModel);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<RegisterUserResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }

    public async Task<ApiResponse<LoginUserResponse>> Login(LoginUserRequest userLoginRequestModel)
    {
      var request = new FormUrlEncodedContent(
                               new List<KeyValuePair<string, string>>
                               {
                                 new KeyValuePair<string, string>("email", userLoginRequestModel.Email),
                                 new KeyValuePair<string, string>("password", userLoginRequestModel.Password),
                               });

      var httpResponse = await this.httpService.Post<FormUrlEncodedContent, LoginUserResponse>($"{URL}/login", request);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<LoginUserResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }
  }
}
