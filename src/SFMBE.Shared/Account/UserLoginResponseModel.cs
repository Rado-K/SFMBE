namespace SFMBE.Shared.Account
{
  using System;

  public class UserLoginResponseModel
  {
    public string Token { get; set; }

    public DateTime Expiration { get; set; }
  }
}
