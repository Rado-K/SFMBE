namespace SFMBE.Services.Data.Gear
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Character;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Character.GetGear;
  using System.Linq;
  using System.Threading.Tasks;

  public class GearsService : IGearsService
  {
    private readonly IRepository<Gear> gearRepository;
    private readonly ICharactersService charactersService;

    public GearsService(
      IRepository<Gear> gearRepository,
      ICharactersService charactersService)
    {
      this.gearRepository = gearRepository;
      this.charactersService = charactersService;
    }

    public async Task<Gear> GetGear()
    {
      var character = await this.charactersService.GetCharacter<GetGearCharacterResponse>();

      var gear = await this.gearRepository
        .All()
        .Where(x => x.Id == character.GearId)
        .Include(x => x.EquippedItems)
        .FirstOrDefaultAsync();

      return gear;
    }

    public async Task<T> GetGear<T>()
    {
      var gear = await this.GetGear();

      return gear.To<T>();
    }
  }
}
