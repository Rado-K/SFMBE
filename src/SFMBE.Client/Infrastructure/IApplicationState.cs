namespace SFMBE.Client.Infrastructure
{
  using System;
  using System.Threading.Tasks;

  public interface IApplicationState
  {
    event Func<Task> OnUserDataChange;

    string SessionId { get; set; }

    bool IsLoggedIn { get; }

    string Username { get; set; }

    string UserToken { get; set; }
  }
}
