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

    //[HttpGet]
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

      throw new NotImplementedException();
    }

    //[HttpPost]
    //[Route(nameof(CreateItem))]
    //public async Task<ActionResult<ApiResponse<ItemsBagResponseModel>>> CreateItem([System.Web.Http.FromBody] ItemCreateRequestModel itemStatsRequestModel)
    //{
    //  if (itemStatsRequestModel == null || !this.ModelState.IsValid)
    //  {
    //    return this.ModelStateErrors<ItemsBagResponseModel>();
    //  }

    //  var response = await this.itemsService.CreateItem(itemStatsRequestModel);

    //  if (response is null)
    //  {
    //    return this.BadRequest("Item is missing.");
    //  }

    //  return this.Ok(response.ToApiResponse());
    //}
  }
}
