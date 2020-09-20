namespace Unit.Tests
{
  using SFMBE.Data;
  using SFMBE.Data.Models;
  using SFMBE.Data.Repositories;
  using SFMBE.Server.Endpoints.Vendors;
  using SFMBE.Shared.Vendors;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.EntityFrameworkCore;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Xunit;

  public class VendorsTests
  {
    private readonly EfRepository<Vendor> repository;

    public VendorsTests()
    {
      var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestVendors")
                .Options;

      var context = new ApplicationDbContext(dbOptions);

      this.repository = new EfRepository<Vendor>(context);
    }

    public static IEnumerable<object[]> IsValidDataForGetOk =>
     new[]
        {
          new dynamic []
          {
            new Vendor
            {
              Items = new[]
              {
                new Item
                {
                  Stamina = 1,
                },
                new Item
                {
                  Stamina = 2,
                }
              }
            },
            1,
          },
        };

    [Theory]
    [MemberData(nameof(IsValidDataForGetOk))]
    public async Task ShouldGetVendorReturnsOk(Vendor vendorForDb, int vendorId)
    {
      var vendor = GetVendorQueryResponse.FromVendor(await this.repository
        .AddAsync(vendorForDb));

      var endpoint = new Get(this.repository);

      var result = await endpoint.HandleAsync(vendorId);

      Assert.NotNull(result);
      Assert.IsAssignableFrom<ActionResult<GetVendorQueryResponse>>(result);
      var model = Assert.IsType<OkObjectResult>(result.Result).Value as GetVendorQueryResponse;

      var actual = vendor.Items.FirstOrDefault().Id;
      var expected = model.Items.FirstOrDefault().Id;

      Assert.Equal(actual, expected);
    }
  }
}