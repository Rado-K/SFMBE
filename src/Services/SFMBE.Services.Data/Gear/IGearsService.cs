namespace SFMBE.Services.Data.Gear
{
  using SFMBE.Data.Models;
  using System;
  using System.Linq.Expressions;
  using System.Threading.Tasks;

  public interface IGearsService
  {
    Task<T> GetGear<T>();
    Task Equip(int id);
    Task<Gear> GetGear();
    Task Unequip(int id);
  }
}
