namespace SFMBE.Client.Repositories.Bags
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Bags.Get;
  using System;
  using System.Threading.Tasks;

  public partial class BagsRepository : IBagsRepository
  {
    private const string URL = "api/bags";
    private readonly IHttpService httpService;

    public BagsRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<ApiResponse<GetBagResponse>> GetBag(GetBagRequest request)
    {
      var httpResponse = await this.httpService.Get<GetBagResponse>(request.RouteFactory);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<GetBagResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }
  }
}
