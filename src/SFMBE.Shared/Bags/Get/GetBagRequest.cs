namespace SFMBE.Shared.Bags.Get
{
  using MediatR;
  using Newtonsoft.Json;

  public class GetBagRequest : IRequest<ApiResponse<GetBagResponse>>
  {
    public const string Route = "api/bags";

    public int BagId { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}?{nameof(this.BagId)}={this.BagId}";
  }
}
