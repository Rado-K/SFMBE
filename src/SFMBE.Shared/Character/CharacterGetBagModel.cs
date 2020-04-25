namespace SFMBE.Shared.Character
{
  using Services.Mapping;
  using Data.Models;

  public class CharacterGetBagModel : IMapFrom<Character>
  {
    public int BagId { get; set; }
  }
}
