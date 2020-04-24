namespace SFMBE.Shared.Items
{
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;

  public class ItemCreateResponseModel : IMapFrom<Item>
  {
    public int Id { get; set; }
  }
}
