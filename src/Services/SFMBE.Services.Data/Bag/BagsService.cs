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

  public class BagsService : IBagsService
  {
    private readonly IDeletableEntityRepository<Bag> bagsRepository;

    public BagsService(IDeletableEntityRepository<Bag> bagService)
    {
      this.bagsRepository = bagService;
    }

    public async Task<int> CreateAsync()
    {
      var bag = new Bag();

      await this.bagsRepository.AddAsync(bag);
      await this.bagsRepository.SaveChangesAsync();

      return bag.Id;
    }

    //public async Task<int> ChangeItemAsync(int itemId, int bagId)
    //{

    //}
    public IEnumerable<Item> GetItemsInBag(int bagId)
    {
      var items = this.bagsRepository.All()
       .Where(b => b.Id == bagId)
       .Select(x =>x.Items)
       .FirstOrDefault();

      return items;
    }
  }
}
