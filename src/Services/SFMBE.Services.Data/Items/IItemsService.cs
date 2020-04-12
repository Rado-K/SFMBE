namespace SFMBE.Services.Data.Items
{
  using SFMBE.Data.Models;
  using SFMBE.Shared.Items;
  using System.Threading.Tasks;

  public interface IItemsService
  {
    Task<ItemResponseModel> CreateAsync(ItemStatsRequestModel userModel);
    T GetById<T>(int id);
  }
}
