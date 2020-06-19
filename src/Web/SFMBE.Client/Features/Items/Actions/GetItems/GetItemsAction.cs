namespace SFMBE.Client.Features.Items
{
  using MediatR;
  using SFMBE.Shared.Items;

  public class GetItemsAction : IRequest<ItemsResponseModel>
  {
    public GetItemsAction(ItemsRequestModel itemsRequestModel)
    {
      this.ItemsRequestModel = itemsRequestModel;
    }

    public ItemsRequestModel ItemsRequestModel { get; }
  }
}
