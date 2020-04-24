namespace SFMBE.Shared.Character
{
  using AutoMapper;
  using Data.Models;
  using Services.Mapping;

  public class CharacterUpdateModel : IMapFrom<CharacterResponseModel>, IMapTo<Character>
  {
    public string Name { get; set; }

    public int Level { get; set; }

    public int Money { get; set; }

    public int Experience { get; set; }

    public int Stamina { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }

    public int Strength { get; set; }

    //public void CreateMappings(IProfileExpression configuration)
    //{
    //  configuration
    //    .CreateMap<CharacterResponseModel, CharacterUpdateModel>()
    //    .ForMember(dest => dest.Agility, act => act.MapFrom(src => src.Agility))
    //    .ForMember(dest => dest.Experience, act => act.MapFrom(src => src.Experience))
    //    .ForMember(dest => dest.Intelligence, act => act.MapFrom(src => src.Intelligence))
    //    .ForMember(dest => dest.Level, act => act.MapFrom(src => src.Level))
    //    .ForMember(dest => dest.Money, act => act.MapFrom(src => src.Money))
    //    .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
    //    .ForMember(dest => dest.Stamina, act => act.MapFrom(src => src.Stamina))
    //    .ForMember(dest => dest.Strength, act => act.MapFrom(src => src.Strength))
    //    .IgnoreAllPropertiesWithAnInaccessibleSetter();
    //}
  }
}
