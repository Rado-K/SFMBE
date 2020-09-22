namespace SFMBE.Server.Endpoints.Vendors
{
  using System.Threading;
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data.Models;
  using SFMBE.Data.Repositories;
  using SFMBE.Data.Specifications.Vendors;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Vendors;

  public class Get : BaseAsyncEndpoint<int, GetVendorQueryResponse>
  {
    private readonly IAsyncRepository<Vendor> vendorRepository;

    public Get(IAsyncRepository<Vendor> vendorRepository)
    {
      this.vendorRepository = vendorRepository;
    }

    [Authorize]
    [HttpGet("api/Vendors/Get")]
    public override async Task<ActionResult<GetVendorQueryResponse>> HandleAsync([FromQuery] int vendorId, CancellationToken cancellationToken = default)
    {
      var spec = new GetVendorSpecification(vendorId);
      var vendor = await this.vendorRepository.FirstOrDefaultAsync(spec);

      return this.Ok(vendor.To<GetVendorQueryResponse>());
    }
  }
}
