namespace Integration.Tests
{
  using System.Net;
  using System.Net.Http;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Mvc.Testing;
  using Xunit;

  public class UsersTest : IClassFixture<TestFixture>
  {
    private readonly HttpClient client;

    public UsersTest(TestFixture factory)
    {
      this.client = factory.CreateClient(new WebApplicationFactoryClientOptions
      {
        AllowAutoRedirect = true
      });
    }

    [Fact]
    public async Task ShouldGetListOfCharacters()
    {
      var response = await this.client.GetAsync("api/Characters/GetList/c");

      Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
  }
}