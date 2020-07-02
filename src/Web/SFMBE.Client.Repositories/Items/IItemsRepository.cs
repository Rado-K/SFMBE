namespace SFMBE.Client.Repositories.Items
{
  using SFMBE.Shared;
  using SFMBE.Shared.Items.Create;
  using SFMBE.Shared.Items.Equip;
  using SFMBE.Shared.Items.GetItems;
  using SFMBE.Shared.Items.Unequip;
  using System.Threading.Tasks;

  public interface IItemsRepository
  {
    Task<ApiResponse<CreateItemResponse>> CreateItem(CreateItemRequest itemCreateRequestModel);
    Task Equip(EquipItemRequest equipItemRequest);
    Task<ApiResponse<GetItemsResponse>> GetItems(GetItemsRequest itemsRequestModel);
    Task Unequip(UnequipItemRequest unequipItemRequest);
  }
}
