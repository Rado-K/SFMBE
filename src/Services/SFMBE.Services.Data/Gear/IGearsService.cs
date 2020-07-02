namespace SFMBE.Services.Data.Gear
{
  using SFMBE.Data.Models;
  using System;
  using System.Linq.Expressions;
  using System.Threading.Tasks;

  public interface IGearsService
  {
    Task<Gear> GetGearById(int id);
    Task<T> GetGearById<T>(int id);
  }
}
