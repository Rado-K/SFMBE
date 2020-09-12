namespace SFMBE.Shared.Characters.Queries
{
  using System.Collections.Generic;
  using System.Linq;
  using SFMBE.Data.Models;
  using SFMBE.Shared.Items.Queries;

  public class GetCharacterQueryResponse
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public int Level { get; set; }

    public int Money { get; set; }

    public byte[] Image { get; set; }

    public int Experience { get; set; }

    public int Stamina { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }

    public int Strength { get; set; }

    public int VendorId { get; set; }

    public IEnumerable<GetItemQueryResponse> Gear { get; set; }

    public IEnumerable<GetItemQueryResponse> Bag { get; set; }

    public static GetCharacterQueryResponse FromCharacter(Character character)
    {
      return new GetCharacterQueryResponse
      {
        Id = character.Id,
        Name = character.Name,
        Level = character.Level,
        Money = character.Money,
        Image = character.Image,
        Experience = character.Experience,
        Stamina = character.Stamina,
        Agility = character.Agility,
        Intelligence = character.Intelligence,
        Strength = character.Strength,
        VendorId = character.VendorId,
        Gear = character.Items.Where(x => x.IsEquip == EquipType.InGear).Select(GetItemQueryResponse.FromItem),
        Bag = character.Items.Where(x => x.IsEquip == EquipType.InBag).Select(GetItemQueryResponse.FromItem)
      };
    }
  }
}
