namespace SFMBE.Client.Respository.Gears
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Gear;
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

    public async Task<ApiResponse<GearResponseModel>> GetGear()
    {
      var httpResponse = await this.httpService.Get<GearResponseModel>($"{URL}");

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<GearResponseModel>(httpResponse.Errors);
      }
 
      return httpResponse;
    }

    public async Task Equip(int id)
    {
      var httpResponse = await this.httpService.Post<object>($"{URL}/{nameof(Equip)}", id);

      if (!httpResponse.IsOk)
      {
        throw new Exception();
      }
    }

    public async Task Unequip(int id)
    {
      var httpResponse = await this.httpService.Post<object>($"{URL}/{nameof(Unequip)}", id);

      if (!httpResponse.IsOk)
      {
        throw new Exception();
      }
    }
  }
}
