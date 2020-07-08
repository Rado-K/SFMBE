namespace SFMBE.Services.Data.Gear
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using System.Linq;
  using System.Threading.Tasks;

  public class GearsService : IGearsService
  {
    private readonly IRepository<Gear> gearRepository;

    public GearsService(
      IRepository<Gear> gearRepository)
    {
      this.gearRepository = gearRepository;
    }

    public async Task<Gear> GetGearById(int id)
    {
      var gear = await this.gearRepository
        .All()
        .Where(x => x.Id == id)
        .Include(x => x.EquippedItems)
        .FirstOrDefaultAsync();

      return gear;
    }

    public async Task<T> GetGearById<T>(int id)
    {
      var gear = await this.GetGearById(id);

      return gear.To<T>();
    }
  }
}
