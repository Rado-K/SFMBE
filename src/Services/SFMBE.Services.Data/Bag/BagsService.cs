namespace SFMBE.Services.Data.Bag
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Character;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Bags;
  using System.Linq;
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

    public async Task<BagResponseModel> GetBag()
    {
      var character = await this.charactersService.GetCharacter<Character>();

      var bag = await this.bagsRepository
        .All()
        .Where(x => x.Id == character.BagId)
        .To<BagResponseModel>()
        .FirstOrDefaultAsync();

      return bag;
    }
  }
}
