namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Services.Data.Items;
  using SFMBE.Shared;
  using SFMBE.Shared.Items.Create;
  using SFMBE.Shared.Items.GetItems;
  using System.Threading.Tasks;

  public class ItemsController : BaseController
  {
    private readonly IItemsService itemsService;

    public ItemsController(IItemsService itemsService)
    {
      this.itemsService = itemsService;
    }

    public async Task<ActionResult<ApiResponse<GetItemsResponse>>> GetItems([FromQuery] GetItemsRequest itemsRequestModel)
    {
      if (itemsRequestModel is null || !this.ModelState.IsValid)
      {
        return this.ModelStateErrors<GetItemsResponse>();
      }

      var response = await this.itemsService.GetItemsById<GetItemsResponse>(itemsRequestModel);

      if (response is null)
      {
        return this.BadRequest("Something is wrong.");
      }

      return this.Ok(response.ToApiResponse());
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<CreateItemResponse>>> CreateItem([FromBody] CreateItemRequest itemCreateRequestModel)
    {
      if (itemCreateRequestModel is null || !this.ModelState.IsValid)
      {
        return this.ModelStateErrors<CreateItemResponse>();
      }

      var response = await this.itemsService.CreateItem(itemCreateRequestModel);

      if (response is null)
      {
        return this.BadRequest("Something is wrong.");
      }

      return this.Ok(response.ToApiResponse());
    }
  }
}
