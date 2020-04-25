namespace SFMBE.Services.Data.Items
{
  using SFMBE.Data.Models;
  using SFMBE.Shared.Items;
  using System.Threading.Tasks;

  public interface IItemsService
  {
    Task<ItemCreateResponseModel> CreateItem(ItemCreateRequestModel userModel);
    Task<T> GetItemById<T>(int id);
    Task<T> GetItemsById<T>(ItemsRequestModel itemsRequestModel);
  }
}
