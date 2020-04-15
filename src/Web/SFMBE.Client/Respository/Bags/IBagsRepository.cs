namespace SFMBE.Client.Respository.Bags
{
  using SFMBE.Shared;
  using SFMBE.Shared.Bags;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public interface IBagsRepository
  {
    Task<ApiResponse<BagResponseModel>> GetBag(int characterId);
  }
}
