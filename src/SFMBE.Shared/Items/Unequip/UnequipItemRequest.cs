namespace SFMBE.Shared.Items.Unequip
{
  using MediatR;
  using Newtonsoft.Json;

  public class UnequipItemRequest : IRequest
  {
    public const string Route = "api/items/unequip";

    public int ItemId { get; set; }
    public int CharacterId { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}";
  }
}
