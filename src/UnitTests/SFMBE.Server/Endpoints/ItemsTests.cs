namespace UnitTests.SFMBE.Server.Endpoints
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using global::SFMBE.Data;
  using global::SFMBE.Data.Models;
  using global::SFMBE.Data.Repositories;
  using global::SFMBE.Server.Endpoints.Items;
  using global::SFMBE.Shared.Items.Commands;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.EntityFrameworkCore;
  using Xunit;

  public class ItemsTests
  {
    private readonly EfRepository<Item> repository;
    private readonly ApplicationDbContext context;

    public ItemsTests()
    {
      var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestItems")
                .Options;

      this.context = new ApplicationDbContext(dbOptions);

      this.repository = new EfRepository<Item>(this.context);
    }

    public static IEnumerable<object[]> IsValidDataForCreateOk =>
     new[]
        {
          new dynamic[]
          {
            new CreateItemCommand
            {
              ItemType = "Sword",
              Level = 1,
              Stamina = 1,
              Strength = 1,
              Agility = 1,
              Intelligence = 1,
              CharacterId = 1
            },
            1
          },
          new dynamic[]
          {
            new CreateItemCommand
            {
              ItemType = "Shield",
              Level = 1,
              Stamina = 1,
              Strength = 1,
              Agility = 1,
              Intelligence = 1,
              VendorId = 1
            },
            2
          }
        };

    [Theory]
    [MemberData(nameof(IsValidDataForCreateOk))]
    public async Task ShouldCreateItemReturnsOk(CreateItemCommand createItemCommand, int output)
    {
      var endpoint = new Create(this.repository);

      var result = await endpoint.HandleAsync(createItemCommand);

      Assert.NotNull(result);
      Assert.IsAssignableFrom<ActionResult<int>>(result);
      var model = Assert.IsType<OkObjectResult>(result.Result);

      Assert.Equal(output, model.Value);
    }
  }
}
