namespace SFMBE.Shared.Character.Get
{
  using MediatR;
  using Newtonsoft.Json;

  public class GetCharacterRequest : IRequest<ApiResponse<GetCharacterResponse>>
  {
    public const string Route = "api/characters/get";

    [JsonIgnore]
    public string RouteFactory => $"{Route}";
  }
}
