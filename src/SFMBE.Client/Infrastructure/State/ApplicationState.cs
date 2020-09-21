namespace SFMBE.Client.Infrastructure.State
{
  using System;
  using System.Threading.Tasks;

  public class ApplicationState : IApplicationState
  {
    private string userToken;

    private string username;

    public ApplicationState()
    {
      this.SessionId = Guid.NewGuid().ToString();
    }

    public string SessionId { get; set; }

    public bool IsLoggedIn { get; }

    public string Username
    {
      get => this.username;
      set
      {
        this.username = value;
        this.OnUserDataChange?.Invoke();
      }
    }

    public string UserToken
    {
      get => this.userToken;
      set
      {
        this.userToken = value;
        this.OnUserDataChange?.Invoke();
      }
    }

    public event Func<Task> OnUserDataChange;
  }
}
