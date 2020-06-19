namespace SFMBE.Client.Repositories.Bags
{
  using SFMBE.Shared;
  using SFMBE.Shared.Bags.Get;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public interface IBagsRepository
  {
    Task<ApiResponse<GetBagResponse>> GetBag();
  }
}
