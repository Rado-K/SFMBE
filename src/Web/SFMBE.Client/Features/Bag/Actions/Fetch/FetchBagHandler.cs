namespace SFMBE.Client.Features.Bag
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Repositories.Bags;
  using SFMBE.Shared.Bags.Get;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class BagState
  {
    internal class FetchBagHandler : BaseHandler<FetchBagAction>
    {
      private readonly IBagsRepository bagsRepository;

      public FetchBagHandler(IBagsRepository bagsRepository, IStore stroe) : base(stroe)
      {
        this.bagsRepository = bagsRepository;
      }

      public override async Task<Unit> Handle(FetchBagAction fetchBagAction, CancellationToken cancellationToken)
      {
        var getBagRequest = new GetBagRequest { BagId = this.CharacterState.Character.Data.BagId };
        var bag = await this.bagsRepository.GetBag(getBagRequest);
        this.BagState.Bag = bag.Data.Items;

        return await Unit.Task;
      }
    }
  }
}
