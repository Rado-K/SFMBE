namespace SFMBE.Server.Controllers.Vendors.Get
{
  using MediatR;
  using SFMBE.Services.Data.Vendor;
  using SFMBE.Shared;
  using SFMBE.Shared.Vendors.Get;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetVendorHandler : IRequestHandler<GetVendorRequest, ApiResponse<GetVendorResponse>>
  {
    private readonly IVendorService vendorService;

    public GetVendorHandler(IVendorService vendorService)
    {
      this.vendorService = vendorService;
    }

    public async Task<ApiResponse<GetVendorResponse>> Handle(GetVendorRequest request, CancellationToken cancellationToken)
    {
      var vendor = await this.vendorService.GetVendorById<GetVendorResponse>(request.VendorId);

      return vendor.ToApiResponse();
    }
  }
}
