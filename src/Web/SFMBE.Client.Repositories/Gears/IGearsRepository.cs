namespace SFMBE.Client.Repositories.Gears
{
  using SFMBE.Shared;
  using SFMBE.Shared.Gear.Get;
  using System;
  using System.Threading.Tasks;

  public interface IGearsRepository
  {
    Task Equip(int id);
    Task Unequip(int id);
    Task<ApiResponse<GetGearResponseModel>> GetGear();
  }
}
