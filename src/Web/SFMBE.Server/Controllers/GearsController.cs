namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Services.Data.Gear;
  using SFMBE.Shared;
  using SFMBE.Shared.Gear.Get;
  using System.Net.NetworkInformation;
  using System.Threading.Tasks;

  public class GearsController : BaseController
  {
    private readonly IGearsService gearsService;

    public GearsController(IGearsService gearsService)
    {
      this.gearsService = gearsService;
    }


    public async Task<ActionResult<ApiResponse<GetGearResponseModel>>> GetGear()
    {
      var response = await this.gearsService.GetGear<GetGearResponseModel>();

      if (response is null)
      {
        return this.BadRequest();
      }

      return this.Ok(response.ToApiResponse());
    }


    [HttpPost]
    [Route(nameof(Equip))]
    public async Task<IActionResult> Equip([FromBody] int id)
    {
      await this.gearsService.Equip(id);

      return this.Ok();
    }

    [HttpPost]
    [Route(nameof(Unequip))]
    public async Task<IActionResult> Unequip([FromBody] int id)
    {
      await this.gearsService.Unequip(id);

      return this.Ok();
    }
  }
}
