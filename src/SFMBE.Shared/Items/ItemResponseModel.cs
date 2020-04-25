namespace SFMBE.Shared.Items
{
  using AutoMapper;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;

  public class ItemResponseModel : IMapFrom<Item>
  {
    public int Id { get; set; }

    public string ItemType { get; set; } = "Empty";

    public int Level { get; set; }

    public int Stamina { get; set; }

    public int Strength { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }

    //public void CreateMappings(IProfileExpression configuration)
    //{
    //  configuration
    //    .CreateMap<Item, ItemResponseModel>()
    //    .ForMember(d => d.ItemType, o => o.MapFrom(s => s.ItemType.ToString()));
    //}
  }
}
