namespace SFMBE.Services.Data.Bag
{
  using SFMBE.Data.Models;
  using SFMBE.Shared.Bags;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  public interface IBagsService
  {
    Task<BagResponseModel> GetBagById(int bagId);
  }
}