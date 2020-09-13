namespace Tests.SFMBE.Server.UnitTests.Endpoints
{
  using global::SFMBE.Server.Endpoints.Authentication;
  using global::SFMBE.Server.Services;
  using global::SFMBE.Shared.Authentication.Commands;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Mvc;
  using Moq;
  using Xunit;

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
        UserName = name,
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
      Assert.IsType<OkResult>(result);
    }

    public static IEnumerable<object[]> IsInvalidDataForCreateBadRequest =>
     new[]
        {
          new dynamic[]
          {
            new RegisterParametersCommand
            {
              UserName = "User1",
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
              UserName = "user1",
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

    public static IEnumerable<object[]> IsValidDataForLoginOK =>
    new[]
       {
          new dynamic[]
          {
            new LoginParametersCommand
            {
              UserName = "user1",
              Password = "user1user1",
            },
            "You are login in"
          },
       };

    [Theory]
    [MemberData(nameof(IsValidDataForLoginOK))]
    public async Task ShouldLoginUserReturnsOk(LoginParametersCommand loginParameters, string output)
    {
      this.mockService.Setup(x => x.Login(loginParameters))
        .ReturnsAsync(output);

      var endpoint = new Login(this.mockService.Object);

      // Act
      var result = await endpoint.HandleAsync(loginParameters);

      Assert.NotNull(result);
      Assert.IsAssignableFrom<IActionResult>(result);
      var model = Assert.IsType<OkObjectResult>(result);
      Assert.Equal(output, model.Value);
    }

    public static IEnumerable<object[]> IsInvalidDataForLoginBadRequest =>
    new[]
       {
          new dynamic[]
          {
            new LoginParametersCommand
            {
              UserName = "user2",
              Password = "123456",
            },
            "Invalid password"
          },
          new dynamic[]
          {
            new LoginParametersCommand
            {
              UserName = "user3",
              Password = "123456",
            },
            "User does not exist"
          },
       };

    [Theory]
    [MemberData(nameof(IsInvalidDataForLoginBadRequest))]
    public async Task ShouldLoginUserReturnsBadRequest(LoginParametersCommand loginParameters, string output)
    {
      this.mockService.Setup(x => x.Login(loginParameters))
        .ReturnsAsync(output);

      var endpoint = new Login(this.mockService.Object);

      // Act
      var result = await endpoint.HandleAsync(loginParameters);

      Assert.NotNull(result);
      Assert.IsAssignableFrom<IActionResult>(result);
      var badObject = Assert.IsType<BadRequestObjectResult>(result);
      Assert.Equal(output, badObject.Value);
    }
  }
}
