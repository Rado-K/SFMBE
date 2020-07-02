namespace SFMBE.Shared.Items.Equip
{
  using MediatR;
  using Newtonsoft.Json;

  public class EquipItemRequest : IRequest
  {
    public const string Route = "api/items/equip";

    public int ItemId { get; set; }
    public int CharacterId { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}";
  }
}
