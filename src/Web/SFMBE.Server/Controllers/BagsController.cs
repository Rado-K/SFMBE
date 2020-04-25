namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Services.Data.Bag;
  using SFMBE.Shared;
  using SFMBE.Shared.Bags;
  using System;
  using System.Collections.Specialized;
  using System.Security.Cryptography.X509Certificates;
  using System.Threading.Tasks;

  public class BagsController : BaseController
  {
    private readonly IBagsService bagsService;

    public BagsController(IBagsService bagsService)
    {
      this.bagsService = bagsService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<BagResponseModel>>> GetBag()
    {
      var response = await this.bagsService.GetBag<BagResponseModel>(x => x.Items);

      if (response is null)
      {
        return this.BadRequest();
      }

      return this.Ok(response.ToApiResponse());
    }
  }
}
//.Where(i => (i.Id == itemId && i.IsEquip == false)
//         || (i.IsEquip && i.ItemType.ToString() == itemType))