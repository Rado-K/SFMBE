namespace SFMBE.Shared.Account.Login
{
  using Newtonsoft.Json;
  using System.ComponentModel.DataAnnotations;

  public class LoginUserRequest
  {
    public const string Route = "api/account/login";

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }


    [JsonIgnore]
    public string RouteFactory => $"{Route}";
  }
}
