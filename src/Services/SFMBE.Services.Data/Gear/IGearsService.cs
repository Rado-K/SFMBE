namespace SFMBE.Services.Data.Gear
{
  using SFMBE.Data.Models;
  using SFMBE.Shared.Gear;
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Threading.Tasks;

  public interface IGearsService
  {
    Task<GearResponseModel> GetGearById(int gearId);
  }
}
