namespace SFMBE.Shared.Account.Login
{
  using System.ComponentModel.DataAnnotations;

  public class LoginUserRequest
  {
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
  }
}
