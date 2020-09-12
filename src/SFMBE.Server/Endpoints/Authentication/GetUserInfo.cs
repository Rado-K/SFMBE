namespace SFMBE.Server.Endpoints.Authentication
{
  using System.Linq;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Shared;

  public class GetUserInfo : BaseAsyncEndpoint
  {
    [HttpGet("api/Authorize/UserInfo")]
    public UserInfo HandleAsync()
    {
      return new UserInfo
      {
        IsAuthenticated = this.User.Identity.IsAuthenticated,
        Username = this.User.Identity.Name,
        ExposedClaims = this.User.Claims
              ////Optionally: filter the claims you want to expose to the client
              ////.Where(c => c.Type == "test-claim")
              .ToDictionary(c => c.Type, c => c.Value)
      };
    }
  }
}
