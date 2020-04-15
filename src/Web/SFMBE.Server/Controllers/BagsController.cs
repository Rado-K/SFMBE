namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Bag;
  using SFMBE.Services.Data.Items;
  using SFMBE.Shared;
  using SFMBE.Shared.Bags;
  using System;
  using System.Linq;
  using System.Threading.Tasks;

  public class BagsController : BaseController
  {
    private readonly IBagsService bagsService;
    private readonly IItemsService itemsService;

    public BagsController(
      IBagsService bagsService,
      IItemsService itemsService)
    {
      this.bagsService = bagsService;
      this.itemsService = itemsService;
    }


    [HttpGet]
    [Route("t")]
    public async Task<ActionResult<ApiResponse<BagResponseModel>>> Get(int bagId = 1, string itemType = "Head", int itemId = 4)
    {
      throw new NotImplementedException();
    }
  }
}
//.Where(i => (i.Id == itemId && i.IsEquip == false)
//         || (i.IsEquip && i.ItemType.ToString() == itemType))