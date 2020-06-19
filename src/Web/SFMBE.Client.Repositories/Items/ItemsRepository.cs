namespace SFMBE.Client.Repositories.Items
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Items.Create;
  using SFMBE.Shared.Items.GetItems;
  using System.Threading.Tasks;

  public class ItemsRepository : IItemsRepository
  {
    private const string URL = "api/items";
    private readonly IHttpService httpService;

    public ItemsRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<ApiResponse<GetItemsResponse>> GetItems(GetItemsRequest itemsRequestModel)
    {
      var requestString = "Items=0" + string.Join("&Items=", itemsRequestModel.Items);

      var httpResponse = await this.httpService.Get<GetItemsResponse>($"{URL}?{requestString}");

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<GetItemsResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }

    public async Task<ApiResponse<CreateItemResponse>> CreateItem(CreateItemRequest itemCreateRequestModel)
    {
      var httpResponse = await this.httpService.PostJson<CreateItemRequest, CreateItemResponse>($"{URL}/CreateItem", itemCreateRequestModel);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<CreateItemResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }
  }
}
