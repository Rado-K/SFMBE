namespace SFMBE.Services.Data.Gear
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Shared.Gear;
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class GearsService : IGearsService
  {
    private readonly IRepository<Gear> gearRepository;

    public GearsService(IRepository<Gear> gearRepository)
    {
      this.gearRepository = gearRepository;
    }

    public async Task<GearResponseModel> GetGearById(int gearId)
    {
      var gear = await this.gearRepository
        .All()
        .Where(x => x.Id == gearId)
        .Select(x =>
            new GearResponseModel
            {
              EquippedItems = x.EquippedItems
              .Select(i =>
                new ItemsBagResponseModel
                {
                  Id = i.Id
                })
              .ToList()
            })
        .FirstOrDefaultAsync();

      return gear;
    }
  }
}
