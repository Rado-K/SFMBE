namespace SFMBE.Server.Controllers.Bags.Get
{
  using MediatR;
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data;
  using SFMBE.Services.Data.Bag;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared;
  using SFMBE.Shared.Bags.Get;
  using SFMBE.Shared.User.Get;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetBagHandler : IRequestHandler<GetBagRequest, ApiResponse<GetBagResponse>>
  {
    private readonly IBagsService bagsService;

    public GetBagHandler(IBagsService bagsService)
    {
      this.bagsService = bagsService;
    }

    public async Task<ApiResponse<GetBagResponse>> Handle(GetBagRequest request, CancellationToken cancellationToken)
    {
      var bag = await this.bagsService.GetBagById<GetBagResponse>(request.BagId);

      return bag.ToApiResponse();
    }
  }
}
