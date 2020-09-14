namespace Tests.SFMBE.Server.IntegrationTests.Endpoints
{
  using global::SFMBE.Server;
  using Microsoft.AspNetCore.Authentication;
  using Microsoft.AspNetCore.Mvc.Testing;
  using Microsoft.AspNetCore.TestHost;
  using Microsoft.Extensions.DependencyInjection;
  using System.Net;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Text;
  using System.Threading.Tasks;
  using Xunit;

  public class CharactersTests : IClassFixture<WebApplicationFactory<Startup>>
  {
    private readonly WebApplicationFactory<Startup> factory;

    public CharactersTests(WebApplicationFactory<Startup> factory)
    {
      this.factory = factory;
    }

    [Fact]
    public async Task BasicEndPointTest()
    {
      // Arrange
      var client = this.factory
        .CreateClient();

      HttpResponseMessage response;
      using (var authString = new StringContent(@"{username: ""rara"", password: ""rarara""}", Encoding.UTF8, "application/json"))
      {
        response = await client.PostAsync("/api/Authorize/Login", authString);
      }

      client.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue(".AspNetCore.Identity.Application");

      //Act
      response = await client.GetAsync("api/Characters/Get");

      // Assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

  }
}
