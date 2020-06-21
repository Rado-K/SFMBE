namespace SFMBE.Shared.Character.Create
{
  using MediatR;
  using Newtonsoft.Json;

  public class CreateCharacterRequest : IRequest<ApiResponse<CreateCharacterResponse>>
  {
    public const string Route = "api/characters/create";

    public string Name { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}";
  }
}
