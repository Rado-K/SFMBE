namespace SFMBE.Client.Respository.Items
{
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class ItemsRepository : IItemsRepository
  {
    private const string URL = "api/characters";
    private readonly IHttpService httpService;

    public ItemsRepository(IHttpService httpService)
    {
      this.httpService = httpService;
    }

    public async Task<ApiResponse<ItemsBagResponseModel>> CreateItem(ItemCreateRequestModel itemCreateRequestModel)
    {
      var httpResponse = await this.httpService.PostJson<ItemCreateRequestModel, ItemsBagResponseModel>($"{URL}/CreateItem", itemCreateRequestModel);

      if (!httpResponse.IsOk)
      {
        return new ApiResponse<ItemsBagResponseModel>(httpResponse.Errors);
      }

      return httpResponse;


    }
  }
}
