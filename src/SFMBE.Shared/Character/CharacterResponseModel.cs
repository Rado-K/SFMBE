namespace SFMBE.Shared.Character
{
  using AutoMapper;
  using Bags;
  using Data.Models;
  using Gear;
  using Services.Mapping;

  public class CharacterResponseModel : IMapFrom<Character>, IHaveCustomMappings
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


    public GearResponseModel Gear { get; set; }

    public BagResponseModel Bag { get; set; }


    public void CreateMappings(IProfileExpression configuration)
    {
      configuration
        .CreateMap<Character, CharacterResponseModel>()
        .ForMember(x => x.Gear, o =>
        {
          o.MapFrom(p => p.Gear);
        })
        .ForMember(x => x.Bag, o =>
        {
          o.MapFrom(p => p.Bag);
        });
    }
  }
}
