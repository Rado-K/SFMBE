namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Services.Data.Gear;
  using SFMBE.Shared;
  using SFMBE.Shared.Gear;
  using System.Threading.Tasks;

  public class GearsController : BaseController
  {
    private readonly IGearsService gearsService;

    public GearsController(IGearsService gearsService)
    {
      this.gearsService = gearsService;
    }


    public async Task<ActionResult<ApiResponse<GearResponseModel>>> GetGear()
    {
      var response = await this.gearsService.GetGear<GearResponseModel>();

      if (response is null)
      {
        return this.BadRequest();
      }

      return this.Ok(response.ToApiResponse());
    }


    [HttpPost]
    public async Task<IActionResult> Equip([FromBody] int id)
    {
      await this.gearsService.Equip(id);

      return this.Ok();
    }
  }
}
