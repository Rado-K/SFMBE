namespace SFMBE.Shared.Account.Register
{
  using System.ComponentModel.DataAnnotations;

  public class RegisterUserRequest
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
  }
}
