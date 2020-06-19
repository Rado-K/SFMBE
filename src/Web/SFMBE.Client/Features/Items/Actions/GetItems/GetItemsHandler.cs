namespace SFMBE.Client.Features.Items
{
  using MediatR;
  using SFMBE.Client.Repositories.Items;
  using SFMBE.Shared.Items.GetItems;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class ItemState
  {
    internal class GetItemsHandler : IRequestHandler<GetItemsAction, GetItemsResponse>
    {
      private readonly IItemsRepository itemsRepository;

      public GetItemsHandler(IItemsRepository itemsRepository)
      {
        this.itemsRepository = itemsRepository;
      }

      public async Task<GetItemsResponse> Handle(GetItemsAction request, CancellationToken cancellationToken)
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
}
