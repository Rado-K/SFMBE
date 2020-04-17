namespace SFMBE.Client.Respository.Items
{
  using SFMBE.Shared;
  using SFMBE.Shared.Items;
  using System.Threading.Tasks;

  public interface IItemsRepository
  {
    Task<ApiResponse<ItemsBagResponseModel>> CreateItem(ItemCreateRequestModel itemCreateRequestModel);
    Task<ApiResponse<ItemsResponseModel>> GetItems(ItemsRequestModel itemsRequestModel);
  }
}
