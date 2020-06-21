namespace SFMBE.Shared.User.Get
{
  using MediatR;
  using Newtonsoft.Json;
  using SFMBE.Data.Models;

  public class GetUserRequest : IRequest<ApplicationUser>
  {
    public const string Route = "api/users";
  }
}
