namespace SFMBE.Client.Respository.Items
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Items;
  using System.Threading.Tasks;

  public class ItemsRepository : IItemsRepository
  {
    private const string URL = "api/items";
    private readonly IHttpService httpService;

    public ItemsRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<ApiResponse<ItemsResponseModel>> GetItems(ItemsRequestModel itemsRequestModel)
    {
      var requestString = "ItemsIds=" + string.Join("&ItemsIds=", itemsRequestModel.Items);

      var httpResponse = await this.httpService.Get<ItemsResponseModel>($"{URL}?{requestString}");

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<ItemsResponseModel>(httpResponse.Errors);
      }

      return httpResponse;
    }

    public async Task<ApiResponse<ItemCreateResponseModel>> CreateItem(ItemCreateRequestModel itemCreateRequestModel)
    {
      var httpResponse = await this.httpService.PostJson<ItemCreateRequestModel, ItemCreateResponseModel>($"{URL}/CreateItem", itemCreateRequestModel);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<ItemCreateResponseModel>(httpResponse.Errors);
      }

      return httpResponse;
    }
  }
}
