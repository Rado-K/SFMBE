namespace SFMBE.Services.Data.Gear
{
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using System;
  using System.Collections.Generic;
  using System.Text;

  public class GearsService : IGearsService
  {
    private readonly IRepository<Gear> gearRepository;

    public GearsService(IRepository<Gear> gearRepository)
    {
      this.gearRepository = gearRepository;
    }


  }
}
