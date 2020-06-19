namespace SFMBE.Shared.Character.Get
{
  using Data.Models;
  using Services.Mapping;

  public class GetCharacterResponse : IMapFrom<Character>
  {
    public string Name { get; set; }

    public int Level { get; set; }

    public int Money { get; set; }

    public byte[] Image { get; set; }

    public int Experience { get; set; }

    public int Stamina { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }

    public int Strength { get; set; }
  }
}
