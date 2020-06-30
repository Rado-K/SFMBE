namespace SFMBE.Services.Data.Bag
{
  using System.Threading.Tasks;

  public interface IBagsService
  {
    Task<T> GetBagById<T>(int bagId);
  }
}