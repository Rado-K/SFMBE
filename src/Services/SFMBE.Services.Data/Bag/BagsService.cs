namespace SFMBE.Services.Data.Bag
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Character;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Character.GetBag;
  using System;
  using System.Linq;
  using System.Linq.Expressions;
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
      var bag = await this.bagsRepository
        .AllAsNoTracking()
        .Where(x => x.Id == bagId)
        .To<T>()
        .FirstOrDefaultAsync();

      return bag;
    }
  }
}
