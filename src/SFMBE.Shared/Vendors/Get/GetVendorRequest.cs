namespace SFMBE.Shared.Vendors.Get
{
  using MediatR;
  using Newtonsoft.Json;

  public class GetVendorRequest : IRequest<ApiResponse<GetVendorResponse>>
  {
    public const string Route = "api/vendors/get";

    public int VendorId { get; set; }

    [JsonIgnore]
    public string RouteFactory => $"{Route}?{nameof(this.VendorId)}={this.VendorId}";
  }
}
