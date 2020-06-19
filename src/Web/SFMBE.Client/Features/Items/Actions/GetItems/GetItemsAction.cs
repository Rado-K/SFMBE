namespace SFMBE.Client.Features.Items
{
  using MediatR;
  using SFMBE.Shared.Items.GetItems;

  internal partial class ItemState
  {
    public class GetItemsAction : IRequest<GetItemsResponse>
    {
      public GetItemsAction(GetItemsRequest itemsRequestModel)
      {
        this.ItemsRequestModel = itemsRequestModel;
      }

      public GetItemsRequest ItemsRequestModel { get; }
    }
  }
}
