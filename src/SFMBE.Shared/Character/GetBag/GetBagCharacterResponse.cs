namespace SFMBE.Shared.Character.GetBag
{
  using Data.Models;
  using Services.Mapping;

  public class GetBagCharacterResponse : IMapFrom<Character>
  {
    public int BagId { get; set; }
  }
}
