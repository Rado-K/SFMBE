namespace SFMBE.Services.Data.Bag
{
  using SFMBE.Data.Models;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  public interface IBagsService
  {
    Task<Bag> CreateBag();
  }
}