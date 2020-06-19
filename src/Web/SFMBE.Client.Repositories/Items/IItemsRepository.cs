namespace SFMBE.Client.Repositories.Items
{
  using SFMBE.Shared;
  using SFMBE.Shared.Items;
  using System.Threading.Tasks;

  public interface IItemsRepository
  {
    Task<ApiResponse<ItemCreateResponseModel>> CreateItem(ItemCreateRequestModel itemCreateRequestModel);
    Task<ApiResponse<ItemsResponseModel>> GetItems(ItemsRequestModel itemsRequestModel);
  }
}
