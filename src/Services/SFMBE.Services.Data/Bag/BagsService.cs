namespace SFMBE.Services.Data.Bag
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Shared.Bags;
  using System.Linq;
  using System.Threading.Tasks;

  public class BagsService : IBagsService
  {
    private readonly IDeletableEntityRepository<Bag> bagsRepository;

    public BagsService(IDeletableEntityRepository<Bag> bagService)
    {
      this.bagsRepository = bagService;
    }

    public async Task<BagResponseModel> GetBagById(int bagId)
    {
      var bag = await this.bagsRepository
        .All()
        .Where(x => x.Id == bagId)
        .Select(x =>
            new BagResponseModel
            {
              Items = x.Items
                  .Select(x => x.Id)
                  .ToList()
            })
        .FirstOrDefaultAsync();

      return bag;
    }
  }
}
