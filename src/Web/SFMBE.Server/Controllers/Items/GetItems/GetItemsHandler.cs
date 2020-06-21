namespace SFMBE.Server.Controllers.Items.GetItems
{
  using MediatR;
  using SFMBE.Services.Data.Items;
  using SFMBE.Shared;
  using SFMBE.Shared.Items.GetItems;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetItemsHandler : IRequestHandler<GetItemsRequest, ApiResponse<GetItemsResponse>>
  {
    private readonly IItemsService itemsService;

    public GetItemsHandler(IItemsService itemsService) => this.itemsService = itemsService;

    public async Task<ApiResponse<GetItemsResponse>> Handle(GetItemsRequest request, CancellationToken cancellationToken)
    {
      var items = await this.itemsService.GetItemsById<GetItemsResponse>(request);
      //var items = await this.db
      //  .Items
      //  .Where(x => request.Items.Contains(x.Id))
      //  .ToListAsync();

      return items.ToApiResponse();
    }
  }
}
