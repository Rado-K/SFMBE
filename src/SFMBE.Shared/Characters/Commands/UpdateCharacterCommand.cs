namespace SFMBE.Shared.Characters.Commands
{
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Characters.Queries;

  public class UpdateCharacterCommand :
    IMapFrom<GetCharacterQueryResponse>,
    IMapTo<Character>,
    IMapFrom<Character>
    {
      public string Name { get; set; }

      public int Level { get; set; }

      public int Money { get; set; }

      public int Experience { get; set; }

      public int Stamina { get; set; }

      public int Agility { get; set; }

      public int Intelligence { get; set; }

      public int Strength { get; set; }
    }
}