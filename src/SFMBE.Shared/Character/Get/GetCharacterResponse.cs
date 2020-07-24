namespace SFMBE.Shared.Character.Get
{
  using AutoMapper;
  using Data.Models;
  using Services.Mapping;
  using SFMBE.Shared.Items.Get;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class GetCharacterResponse : IMapFrom<Character>, IHaveCustomMappings
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

    public IList<GetItemResponse> Gear { get; set; }

    public IList<GetItemResponse> Bag { get; set; }

    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<Character, GetCharacterResponse>()
        .ForMember(x => x.Gear,
                   o => o.MapFrom(
                    x => x.Items
                    .Where(x => x.IsEquip == EquipType.InGear)))
        .ForMember(x => x.Bag,
                   o => o.MapFrom(
                    x => x.Items
                    .Where(x => x.IsEquip == EquipType.InBag)));
    }
  }
}