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
    [Route("create")]
    public async Task<ActionResult<ApiResponse<ItemResponseModel>>> Create(ItemStatsRequestModel itemStatsRequestModel)
    {
      if (itemStatsRequestModel == null || !this.ModelState.IsValid)
      {
        return this.ModelStateErrors<ItemResponseModel>();
      }

      var response = await this.itemsService.CreateAsync(itemStatsRequestModel);

      if (response is null)
      {
        return this.BadRequest("Invalid item!");
      }

      return this.Ok(response);
    }
  }
}
