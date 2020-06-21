namespace SFMBE.Server.Controllers.Gear.Get
{
  using MediatR;
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data;
  using SFMBE.Services.Data.Gear;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared;
  using SFMBE.Shared.Gear.Get;
  using System.Linq;
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
      var gear = await this.db
        .Gears
        .Where(x => x.Id == request.GearId)
        .Select(x =>
              x.EquippedItems
               .Select(i => i.Id))
        .To<GetGearResponse>()
        .FirstOrDefaultAsync();

      return gear.ToApiResponse();
    }
  }
}
