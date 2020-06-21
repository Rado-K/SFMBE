namespace SFMBE.Client.Repositories.Gears
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Gear.Get;
  using SFMBE.Shared.Items.Equip;
  using SFMBE.Shared.Items.Unequip;
  using System;
  using System.Threading.Tasks;

  public class GearsRepository : IGearsRepository
  {
    private const string URL = "api/gears";
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

    public async Task Equip(EquipItemRequest equipItemRequest)
    {
      var httpResponse = await this.httpService.Post<object>(equipItemRequest.RouteFactory, equipItemRequest);

      if (!httpResponse.IsOk)
      {
        throw new Exception();
      }
    }

    public async Task Unequip(UnequipItemRequest unequipItemRequest)
    {
      var httpResponse = await this.httpService.Post<object>(unequipItemRequest.RouteFactory, unequipItemRequest);

      if (!httpResponse.IsOk)
      {
        throw new Exception();
      }
    }
  }
}
