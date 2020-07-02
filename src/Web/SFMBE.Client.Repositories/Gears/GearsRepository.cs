namespace SFMBE.Client.Repositories.Gears
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Gear.Get;
  using System.Threading.Tasks;

  public class GearsRepository : IGearsRepository
  {
    private readonly IHttpService httpService;

    public GearsRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<ApiResponse<GetGearResponse>> GetGear(GetGearRequest getGearRequest)
    {
      var httpResponse = await this.httpService.Get<GetGearResponse>(getGearRequest.RouteFactory);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<GetGearResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }
  }
}
