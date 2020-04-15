namespace SFMBE.Services.Data.Bag
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  using SFMBE.Data.Models;
  using SFMBE.Data.Common.Repositories;
  using System.Threading.Tasks;
  using System.Linq;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Bags;
  using SFMBE.Shared.Items;
  using Microsoft.EntityFrameworkCore;

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
              .Select(i =>
                  new ItemsBagResponseModel
                  {
                    Id = i.Id
                  })
              .ToList()
            })
        .FirstOrDefaultAsync();

      return bag;
    }
  }
}
