namespace SFMBE.Web.Infrastructure.Middlewares.Authorization
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  public class UserToken
  {
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
  }
}
