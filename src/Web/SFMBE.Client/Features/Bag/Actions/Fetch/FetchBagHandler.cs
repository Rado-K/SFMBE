namespace SFMBE.Client.Features.Bag
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Features.Items;
  using SFMBE.Client.Repositories.Bags;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class BagState
  {
    internal class FetchBagHandler : BaseHandler<FetchBagAction>
    {
      private readonly IBagsRepository bagsRepository;
      private readonly IMediator mediator;

      public FetchBagHandler(IBagsRepository bagsRepository, IMediator mediator, IStore stroe) : base(stroe)
      {
        this.bagsRepository = bagsRepository;
        this.mediator = mediator;
      }

      public override async Task<Unit> Handle(FetchBagAction fetchBagAction, CancellationToken cancellationToken)
      {
        var bag = await this.bagsRepository.GetBag();
        var requestModel = bag.Data.Items.To<ItemsRequestModel>();
        var response = await this.mediator.Send(new GetItemsAction(requestModel));
        this.BagState.Bag = response.Items;

        return await Unit.Task;
      }
    }
  }
}
