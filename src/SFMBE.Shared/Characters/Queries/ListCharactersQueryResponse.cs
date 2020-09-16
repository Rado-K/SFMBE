namespace SFMBE.Shared.Characters.Queries
{
  using SFMBE.Data.Models;

  public class ListCharactersQueryResponse
  {
    public string Name { get; set; }

    public int Level { get; set; }

    public string Guild { get; set; } = "None.";

    public static ListCharactersQueryResponse FromCharacter(Character character)
    {
      return new ListCharactersQueryResponse
      {
        Name = character.Name,
        Level = character.Level,
      };
    }
  }
}
