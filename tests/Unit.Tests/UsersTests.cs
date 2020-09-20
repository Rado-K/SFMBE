namespace Unit.Tests
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Mvc;
  using Moq;
  using Xunit;
  using SFMBE.Server.Services;
  using SFMBE.Shared.Authentication.Commands;
  using SFMBE.Server.Endpoints.Authentication;

  public class UsersTests
  {
    private readonly Mock<IUsersService> mockService;

    public UsersTests() => this.mockService = new Mock<IUsersService>();

    [Fact]
    public async Task ShouldCreateUserReturnsOk()
    {
      const string name = "User1";

      // Arrange
      var registerParameters = new RegisterParametersCommand
      {
        Email = name,
        Password = "123456",
        PasswordConfirm = "123456"
      };

      this.mockService.Setup(x => x.Register(registerParameters))
        .ReturnsAsync(IdentityResult.Success);

      var endpoint = new Register(this.mockService.Object);

      // Act
      var result = await endpoint.HandleAsync(registerParameters);

      // Assert
      Assert.NotNull(result);
      Assert.IsAssignableFrom<IActionResult>(result);
      //Assert.IsType<OkResult>(result);
    }

    public static IEnumerable<object[]> IsInvalidDataForCreateBadRequest =>
     new[]
        {
          new dynamic[]
          {
            new RegisterParametersCommand
            {
              Email = "User1",
              Password = "123",
              PasswordConfirm = "123"
            },
            new IdentityError
            {
              Code = "PasswordTooShort",
              Description = "Passwords must be at least 6 characters."
            }
          },
          new dynamic[]
          {
            new RegisterParametersCommand
            {
              Email = "user1",
              Password = "123456",
              PasswordConfirm = "654321"
            },
            new IdentityError
            {
              Code = "DuplicateUserName",
              Description = "User name 'user1' is already taken."
            }
          },
        };

    [Theory]
    [MemberData(nameof(IsInvalidDataForCreateBadRequest))]
    public async Task ShouldCreateUserReturnsBadRequest(RegisterParametersCommand registerPaparameters, IdentityError errors)
    {
      var mockService = new Mock<IUsersService>();
      mockService.Setup(x => x.Register(registerPaparameters))
        .ReturnsAsync(IdentityResult.Failed(errors));

      var endpoint = new Register(mockService.Object);

      // Act
      var result = await endpoint.HandleAsync(registerPaparameters);

      // Assert
      Assert.NotNull(result);
      Assert.IsAssignableFrom<IActionResult>(result);
      Assert.IsType<BadRequestObjectResult>(result);
    }
  }
}
