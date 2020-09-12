namespace SFMBE.Shared
{
  using System.Collections.Generic;

  public class UserInfo
  {
    public bool IsAuthenticated { get; set; }

    public string Username { get; set; }

    public Dictionary<string, string> ExposedClaims { get; set; }
  }
}