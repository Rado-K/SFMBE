namespace Integration.Tests
{
  using System.Net.Http;
  using Microsoft.AspNetCore.Mvc.Testing;
  using SFMBE.Server;
  using Xunit;
  
  public class UsersTest
  {
    private readonly HttpClient client;

    public UsersTest()
    {
      this.client = new WebApplicationFactory<Startup>().CreateClient();
    }

    [Fact]
    public void TestName()
    {
      //Given

      //When

      //Then
    }
  }
}