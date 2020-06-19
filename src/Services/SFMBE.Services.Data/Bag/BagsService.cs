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
    private readonly ICharactersService charactersService;

    public BagsService(
      IDeletableEntityRepository<Bag> bagService,
      ICharactersService charactersService)
    {
      this.bagsRepository = bagService;
      this.charactersService = charactersService;
    }

    public async Task<T> GetBag<T>(params Expression<Func<Bag, object>>[] properties)
    {
      var character = await this.charactersService.GetCharacter<GetBagCharacterResponse>();

      var bag = await this.bagsRepository
        .All()
        .Where(x => x.Id == character.BagId)
        .To<T>()
        .FirstOrDefaultAsync();

      return bag;
    }
  }
}
