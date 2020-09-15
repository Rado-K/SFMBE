namespace SFMBE.Shared.Authentication.Commands
{
  using System.ComponentModel.DataAnnotations;

  public class LoginParametersCommand
  {
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
  }
}