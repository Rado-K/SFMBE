namespace SFMBE.Client.Features.Items
{
  using MediatR;
  using SFMBE.Client.Repositories.Items;
  using SFMBE.Shared.Items;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetItemsHandler : IRequestHandler<GetItemsAction, ItemsResponseModel>
  {
    private readonly IItemsRepository itemsRepository;

    public GetItemsHandler(IItemsRepository itemsRepository)
    {
      this.itemsRepository = itemsRepository;
    }

    public async Task<ItemsResponseModel> Handle(GetItemsAction request, CancellationToken cancellationToken)
    {
      var response = await this.itemsRepository.GetItems(request.ItemsRequestModel);

      if (response.IsOk)
      {
        return response.Data;
      }

      throw new System.InvalidOperationException();
    }
  }
}
