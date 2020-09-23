namespace SFMBE.Shared.Characters.Queries
{
  using System.Collections.Generic;
  using System.Linq;
  using AutoMapper;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items.Queries;

  public class GetCharacterQueryResponse : IMapFrom<Character>, IHaveCustomMappings
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

    public IList<GetItemQueryResponse> Gear { get; set; }

    public IList<GetItemQueryResponse> Bag { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<Character, GetCharacterQueryResponse>()
        .ForMember(x => x.Gear,
                   o => o.MapFrom(
                    x => x.Items
                    .Where(f => f.IsEquip == EquipType.InGear)))
        .ForMember(x => x.Bag,
                   o => o.MapFrom(
                    x => x.Items
                    .Where(f => f.IsEquip == EquipType.InBag)));
    }
  }
}
