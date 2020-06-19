namespace SFMBE.Shared.Items.Create
{
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;

  public class CreateItemResponse : IMapFrom<Item>
  {
    public int Id { get; set; }
  }
}
