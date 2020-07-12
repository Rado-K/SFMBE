namespace SFMBE.Shared.Character.Get
{
  using MediatR;
  using Newtonsoft.Json;

  public class GetCharacterRequest : IRequest<ApiResponse<GetCharacterResponse>>
  {
    public const string Route = "api/characters/get";

    public int CharacterId { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}";

    //public string RouteFactory => $"{Route}?{nameof(this.CharacterId)}={this.CharacterId}";
  }
}
