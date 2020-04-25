namespace SFMBE.Shared.Character
{
  using Data.Models;
  using Services.Mapping;

  public class CharacterGetGearModel : IMapFrom<Character>
  {
    public int GearId { get; set; }
  }
}
