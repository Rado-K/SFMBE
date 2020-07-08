namespace SFMBE.Services.Data.Bag
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using System.Linq;
  using System.Threading.Tasks;

  public class BagsService : IBagsService
  {
    private readonly IDeletableEntityRepository<Bag> bagsRepository;

    public BagsService(
      IDeletableEntityRepository<Bag> bagsRepository)
    {
      this.bagsRepository = bagsRepository;
    }

    public async Task<T> GetBagById<T>(int bagId)
    {
      var bag = await this.GetBagById(bagId);

      return bag.To<T>();
    }

    public async Task<Bag> GetBagById(int bagId)
    {
      var bag = await this.bagsRepository
        .AllAsNoTracking()
        .Where(x => x.Id == bagId)
        .Include(x => x.Items)
        .FirstOrDefaultAsync();

      return bag;
    }
  }
}
