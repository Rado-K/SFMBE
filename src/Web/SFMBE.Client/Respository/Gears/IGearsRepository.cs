namespace SFMBE.Client.Respository.Gears
{
  using SFMBE.Shared;
  using SFMBE.Shared.Gear;
  using System.Threading.Tasks;

  public interface IGearsRepository
  {
    Task<ApiResponse<object>> Equip(int id);
    Task<ApiResponse<GearResponseModel>> GetGear();
    Task<ApiResponse<object>> Unequip(int id);
  }
}
