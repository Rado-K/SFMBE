namespace SFMBE.Shared.Character.GetGear
{
  using Data.Models;
  using Services.Mapping;

  public class GetGearCharacterResponse : IMapFrom<Character>
  {
    public int GearId { get; set; }
  }
}
