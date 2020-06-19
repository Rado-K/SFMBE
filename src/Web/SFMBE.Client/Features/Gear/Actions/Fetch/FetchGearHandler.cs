namespace SFMBE.Client.Features.Gear
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Features.Items;
  using SFMBE.Client.Repositories.Gears;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Items;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class GearState
  {
    internal class FetchGearHandler : BaseHandler<FetchGearAction>
    {
      private readonly IGearsRepository gearsRepository;
      private readonly IMediator mediator;

      public FetchGearHandler(IGearsRepository gearsRepository, IMediator mediator, IStore store) : base(store)
      {
        this.gearsRepository = gearsRepository;
        this.mediator = mediator;
      }

      public override async Task<Unit> Handle(FetchGearAction aAction, CancellationToken aCancellationToken)
      {
        var gear = await this.gearsRepository.GetGear();
        var requestModel = gear.Data.Items.To<ItemsRequestModel>();
        var response = await this.mediator.Send(new GetItemsAction(requestModel));
        this.GearState.Gear = response.Items;

        return await Unit.Task;
      }
    }
  }
}
