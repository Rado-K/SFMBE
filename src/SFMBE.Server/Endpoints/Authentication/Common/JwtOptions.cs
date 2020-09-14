namespace SFMBE.Server.Endpoints.Authentication.Common
{
  using System;
  using System.Threading.Tasks;

  public class JwtOptions
  {
    public string Path { get; set; } = "/token";

    public string SecretKey { get; set; }

    public string Issuer { get; set; }

    public string Audience { get; set; }

    public TimeSpan Expiration { get; set; } = TimeSpan.FromDays(15);

    public Func<Task<string>> NonceGenerator { get; set; } = () => Task.FromResult(Guid.NewGuid().ToString());
  }
}
