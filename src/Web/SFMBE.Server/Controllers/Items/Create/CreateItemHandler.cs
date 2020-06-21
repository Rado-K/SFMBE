namespace SFMBE.Server.Controllers.Items.Create
{
  using MediatR;
  using SFMBE.Services.Data.Items;
  using SFMBE.Shared;
  using SFMBE.Shared.Items.Create;
  using System.Threading;
  using System.Threading.Tasks;

  public class CreateItemHandler : IRequestHandler<CreateItemRequest, ApiResponse<CreateItemResponse>>
  {
    private readonly IItemsService itemsService;

    public CreateItemHandler(IItemsService itemsService) => this.itemsService = itemsService;

    public async Task<ApiResponse<CreateItemResponse>> Handle(CreateItemRequest request, CancellationToken cancellationToken)
    {
      var item = await this.itemsService.CreateItem(request);

      return item.ToApiResponse();
    }
  }
}
