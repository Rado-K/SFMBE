namespace SFMBE.Shared.Account.Login
{
  using System;

  public class LoginUserResponse
  {
    public string Token { get; set; }

    public DateTime Expiration { get; set; }
  }
}
