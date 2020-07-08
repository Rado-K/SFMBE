namespace SFMBE.Services.Data.Bag
{
  using SFMBE.Data.Models;
  using System.Threading.Tasks;

  public interface IBagsService
  {
    Task<T> GetBagById<T>(int bagId);
    Task<Bag> GetBagById(int bagId);
  }
}