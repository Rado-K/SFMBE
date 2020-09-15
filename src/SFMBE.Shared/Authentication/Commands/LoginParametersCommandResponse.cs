using System.Collections.Generic;

namespace SFMBE.Shared.Authentication.Commands
{
  public class LoginParametersCommandResponse
  {
    public string token { get; set; }

    public IEnumerable<string> roles { get; set; }

    public int expires_in { get; set; }
  }
}
