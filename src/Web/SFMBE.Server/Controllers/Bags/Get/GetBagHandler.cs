namespace SFMBE.Server.Controllers.Bags.Get
{
  using MediatR;
  using Microsoft.AspNetCore.Http;
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared;
  using SFMBE.Shared.Bags.Get;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetBagHandler : IRequestHandler<GetBagRequest, ApiResponse<GetBagResponse>>
  {
    private readonly ApplicationDbContext db;
    private readonly IHttpContextAccessor httpContext;

    public GetBagHandler(ApplicationDbContext db, IHttpContextAccessor httpContext)
    {
      this.db = db;
      this.httpContext = httpContext;
    }

    public async Task<ApiResponse<GetBagResponse>> Handle(GetBagRequest request, CancellationToken cancellationToken)
    {
      var bag = await this.db
        .Bags
        .Where(x => x.Id == request.BagId)
        .Select(x => 
              x.Items
               .Where(i => !i.GearId.HasValue)
               .Select(i => i.Id))
        .To<GetBagResponse>()
        .FirstOrDefaultAsync();

      return bag.ToApiResponse();
    }
  }
}
