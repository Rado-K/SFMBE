namespace SFMBE.Shared.Characters.Queries
{
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;

  public class ListCharactersQueryResponse : IMapFrom<Character>
  {
    public string Name { get; set; }

    public int Level { get; set; }

    public string Guild { get; set; } = "None.";
  }
} 