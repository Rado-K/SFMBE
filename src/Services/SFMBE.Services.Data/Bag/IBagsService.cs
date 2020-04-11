using SFMBE.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFMBE.Services.Data.Bag
{
  public interface IBagsService
  {
    Task<int> CreateAsync();
  
    IEnumerable<Item> GetItemsInBag(int bagId);
  }
}