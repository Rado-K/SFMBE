namespace SFMBE.Shared.Account
{
  using System.ComponentModel.DataAnnotations;

  public class UserLoginRequestModel
  {
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
  }
}
