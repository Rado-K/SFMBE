namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Services.Data.Items;
  using SFMBE.Shared;
  using SFMBE.Shared.Items;
  using System;
  using System.Threading.Tasks;

  public class ItemsController : BaseController
  {
    private readonly IItemsService itemsService;

    public ItemsController(IItemsService itemsService)
    {
      this.itemsService = itemsService;
    }

    public async Task<ActionResult<ApiResponse<ItemsResponseModel>>> GetItems([FromQuery] ItemsRequestModel itemsRequestModel)
    {
      if (itemsRequestModel is null || !this.ModelState.IsValid)
      {
        return this.ModelStateErrors<ItemsResponseModel>();
      }

      var response = await this.itemsService.GetItemsByIds(itemsRequestModel);

      if (response is null)
      {
        return this.BadRequest("Something is wrong.");
      }

      return this.Ok(response.ToApiResponse());
    }
  }
}
