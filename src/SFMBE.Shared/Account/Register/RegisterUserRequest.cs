namespace SFMBE.Shared.Account.Register
{
  using MediatR;
  using System.ComponentModel.DataAnnotations;

  public class RegisterUserRequest : IRequest<ApiResponse<RegisterUserResponse>>
  {
    public const string Route = "api/account/register";

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
  }
}
