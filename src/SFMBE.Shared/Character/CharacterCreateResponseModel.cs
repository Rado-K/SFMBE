namespace SFMBE.Shared.Character
{
  using Services.Mapping;
  using Data.Models;

  public class CharacterCreateResponseModel : IMapFrom<Character>
  {
    public int Id { get; set; }
  }
}
