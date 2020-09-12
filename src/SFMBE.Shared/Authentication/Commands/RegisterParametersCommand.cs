namespace SFMBE.Shared.Authentication.Commands
{
  using System.ComponentModel.DataAnnotations;

  public class RegisterParametersCommand
  {
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string PasswordConfirm { get; set; }
  }
}