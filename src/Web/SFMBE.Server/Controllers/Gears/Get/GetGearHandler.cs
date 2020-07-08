namespace SFMBE.Server.Controllers.Gear.Get
{
  using MediatR;
  using SFMBE.Data;
  using SFMBE.Services.Data.Gear;
  using SFMBE.Shared;
  using SFMBE.Shared.Gear.Get;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetGearHandler : IRequestHandler<GetGearRequest, ApiResponse<GetGearResponse>>
  {
    private readonly ApplicationDbContext db;
    private readonly IGearsService gearsService;

    public GetGearHandler(ApplicationDbContext db, IGearsService gearsService)
    {
      this.db = db;
      this.gearsService = gearsService;
    }

    public async Task<ApiResponse<GetGearResponse>> Handle(GetGearRequest request, CancellationToken cancellationToken)
    {
      var gear = await this.gearsService.GetGearById<GetGearResponse>(request.GearId);

      return gear.ToApiResponse();
    }
  }
}
