namespace SFMBE.Shared.Items.Create
{
  using MediatR;
  using Newtonsoft.Json;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;

  public class CreateItemRequest : IMapFrom<Character>, IRequest<ApiResponse<CreateItemResponse>>
  {
    public const string Route = "api/items/create";

    public string ItemType { get; set; }

    public int Level { get; set; }

    public int Stamina { get; set; }

    public int Strength { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }

    public int? VendorId { get; set; }
    public int? CharacterId { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}";
  }
}
