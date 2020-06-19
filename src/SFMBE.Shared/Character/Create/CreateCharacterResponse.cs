namespace SFMBE.Shared.Character.Create
{
  using Data.Models;
  using Services.Mapping;

  public class CreateCharacterResponse : IMapFrom<Character>
  {
    public int Id { get; set; }
  }
}
