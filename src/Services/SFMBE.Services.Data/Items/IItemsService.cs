namespace SFMBE.Services.Data.Items
{
  using SFMBE.Shared.Items.Create;
  using SFMBE.Shared.Items.GetItems;
  using System.Threading.Tasks;

  public interface IItemsService
  {
    Task<CreateItemResponse> CreateItem(CreateItemRequest userModel);
    Task<T> GetItemById<T>(int id);
    Task<T> GetItemsById<T>(GetItemsRequest itemsRequestModel);
    Task Equip(int id);
    Task Unequip(int id);
  }
}
