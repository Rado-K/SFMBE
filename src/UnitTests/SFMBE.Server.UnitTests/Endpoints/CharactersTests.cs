namespace Tests.SFMBE.Server.UnitTests.Endpoints
{
  using global::SFMBE.Data;
  using global::SFMBE.Data.Models;
  using global::SFMBE.Data.Repositories;
  using global::SFMBE.Server.Endpoints.Characters;
  using global::SFMBE.Server.Services;
  using global::SFMBE.Shared.Characters.Queries;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.EntityFrameworkCore;
  using Moq;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using Xunit;

  public class CharactersTests
  {
    private readonly EfRepository<Character> repository;
    private readonly ApplicationDbContext context;

    public CharactersTests()
    {
      var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestCharacters")
                .Options;

      this.context = new ApplicationDbContext(dbOptions);

      this.repository = new EfRepository<Character>(this.context);
    }

    public static IEnumerable<object[]> IsValidDataForCreateOk =>
     new[]
        {
          new[]
          {
            "character1",
            "user1",
          },
        };

    [Theory]
    [MemberData(nameof(IsValidDataForCreateOk))]
    public async Task ShouldCreateCharacterReturnsOk(string characterName, string userName)
    {
      var mockUsersService = new Mock<IUsersService>();
      mockUsersService
      .Setup(x => x.GetUser())
      .ReturnsAsync(new ApplicationUser { UserName = userName });

      var endpoint = new Create(this.repository, mockUsersService.Object);

      var result = await endpoint.HandleAsync(characterName);

      Assert.NotNull(result);
      Assert.IsAssignableFrom<ActionResult<int>>(result);
      var model = Assert.IsType<OkObjectResult>(result.Result);

      Assert.Equal(3, model.Value);
    }

    public static IEnumerable<object[]> IsValidDataForGetOk =>
     new[]
        {
          new dynamic[]
          {
            "00000000-0000-0000-0000-000000000000",
          },
        };

    [Theory]
    [MemberData(nameof(IsValidDataForGetOk))]
    public async Task ShouldGetCharacterReturnsOk(string userId)
    {
      var user = new ApplicationUser { Id = userId };

      var mockUsersService = new Mock<IUsersService>();
      mockUsersService
      .Setup(x => x.GetUser())
      .ReturnsAsync(user);

      var character = await this.repository.AddAsync(new Character { User = user });

      var endpoint = new Get(this.repository, mockUsersService.Object);

      var result = await endpoint.HandleAsync();

      Assert.NotNull(result);
      Assert.IsAssignableFrom<ActionResult<GetCharacterQueryResponse>>(result);
      var model = Assert.IsType<OkObjectResult>(result.Result).Value as GetCharacterQueryResponse;
      Assert.Equal(character.Id, model.Id);
    }

    public static IEnumerable<object[]> IsInvalidDataForGetBadRequest =>
     new[]
        {
          new dynamic[]
          {
             new ApplicationUser { Id = "00000000-1111-0000-0000-000000000000" },
            "Character not found",
          },
          new dynamic[]
          {
             default,
            "You're not log in."
          },
        };

    [Theory]
    [MemberData(nameof(IsInvalidDataForGetBadRequest))]
    public async Task ShouldGetCharacterReturnsBadRequest(ApplicationUser user, string output)
    {
      var mockUsersService = new Mock<IUsersService>();
      mockUsersService
      .Setup(x => x.GetUser())
      .ReturnsAsync(user);

      if (user == null)
      {
        await this.repository.AddAsync(new Character { User = user });
      }

      var endpoint = new Get(this.repository, mockUsersService.Object);

      var result = await endpoint.HandleAsync();

      Assert.NotNull(result);
      Assert.IsAssignableFrom<ActionResult<GetCharacterQueryResponse>>(result);
      var model = Assert.IsType<BadRequestObjectResult>(result.Result).Value;
      Assert.Equal(output, model);
    }
  }
}
