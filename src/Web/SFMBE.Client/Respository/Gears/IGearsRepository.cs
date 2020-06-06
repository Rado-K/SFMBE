namespace SFMBE.Client.Respository.Gears
{
  using SFMBE.Shared;
  using SFMBE.Shared.Gear;
  using System;
  using System.Threading.Tasks;

  public interface IGearsRepository
  {
    Task Equip(int id);
    Task Unequip(int id);
    Task<ApiResponse<GearResponseModel>> GetGear();
  }
}
