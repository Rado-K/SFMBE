namespace SFMBE.Client.Repositories.Gears
{
  using SFMBE.Shared;
  using SFMBE.Shared.Gear.Get;
  using SFMBE.Shared.Items.Equip;
  using SFMBE.Shared.Items.Unequip;
  using System.Threading.Tasks;

  public interface IGearsRepository
  {
    Task Equip(EquipItemRequest equipItemRequest);
    Task Unequip(UnequipItemRequest unequipItemRequest);
    Task<ApiResponse<GetGearResponse>> GetGear(GetGearRequest getGearRequest);
  }
}
