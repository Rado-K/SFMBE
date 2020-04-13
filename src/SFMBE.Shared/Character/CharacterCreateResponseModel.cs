namespace SFMBE.Shared.Character
{
  using SFMBE.Services.Mapping;
  using SFMBE.Data.Models;

  public class CharacterCreateResponseModel : IMapFrom<Character>
  {
    public int Id { get; set; }
  }
}
