﻿namespace SFMBE.Client.Repositories.Items
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Items.Create;
  using SFMBE.Shared.Items.GetItems;
  using System.Threading.Tasks;

  public class ItemsRepository : IItemsRepository
  {
    private readonly IHttpService httpService;

    public ItemsRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<ApiResponse<GetItemsResponse>> GetItems(GetItemsRequest getItemRequest)
    {
      var httpResponse = await this.httpService.Get<GetItemsResponse>(getItemRequest.RouteFactory);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<GetItemsResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }

    public async Task<ApiResponse<CreateItemResponse>> CreateItem(CreateItemRequest createItemRequest)
    {
      var httpResponse = await this.httpService.PostJson<CreateItemRequest, CreateItemResponse>(createItemRequest.RouteFactory, createItemRequest);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<CreateItemResponse>(httpResponse.Errors);
      }

      return httpResponse;
    }
  }
}
