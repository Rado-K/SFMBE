namespace SFMBE.Client.Repositories.Items
{
  using SFMBE.Shared;
  using SFMBE.Shared.Items.Create;
  using SFMBE.Shared.Items.GetItems;
  using System.Threading.Tasks;

  public interface IItemsRepository
  {
    Task<ApiResponse<CreateItemResponse>> CreateItem(CreateItemRequest itemCreateRequestModel);
    Task<ApiResponse<GetItemsResponse>> GetItems(GetItemsRequest itemsRequestModel);
  }
}
