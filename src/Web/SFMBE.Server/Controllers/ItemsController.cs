namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Items;
  using SFMBE.Shared;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class ItemsController : BaseController
  {
    private readonly IItemsService itemsService;

    public ItemsController(IItemsService itemsService)
    {
      this.itemsService = itemsService;
    }

    [HttpPost]
    [Route(nameof(CreateItem))]
    public async Task<ActionResult<ApiResponse<ItemsBagResponseModel>>> CreateItem([FromBody] ItemCreateRequestModel itemStatsRequestModel)
    {
      if (itemStatsRequestModel == null || !this.ModelState.IsValid)
      {
        return this.ModelStateErrors<ItemsBagResponseModel>();
      }

      var response = await this.itemsService.CreateItem(itemStatsRequestModel);

      if (response is null)
      {
        return this.BadRequest("Item is missing.");
      }

      return this.Ok(response.ToApiResponse());
    }
  }
}
