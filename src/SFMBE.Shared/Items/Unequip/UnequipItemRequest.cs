namespace SFMBE.Shared.Items.Unequip
{
  using Newtonsoft.Json;

  public class UnequipItemRequest
  {
    public const string Route = "api/items/unequip";

    public int ItemId { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}";
  }
}
