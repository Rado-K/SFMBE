namespace SFMBE.Client.Features.Gear
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Repositories.Gears;
  using SFMBE.Shared.Gear.Get;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class GearState
  {
    internal class FetchGearHandler : BaseHandler<FetchGearAction>
    {
      private readonly IGearsRepository gearsRepository;

      public FetchGearHandler(IGearsRepository gearsRepository, IStore store) : base(store)
      {
        this.gearsRepository = gearsRepository;
      }

      public override async Task<Unit> Handle(FetchGearAction aAction, CancellationToken aCancellationToken)
      {
        var getGearRequest = new GetGearRequest { GearId = this.CharacterState.Character.Data.GearId };
        var gear = await this.gearsRepository.GetGear(getGearRequest);
        this.GearState.Gear = gear.Data.Items;

        return await Unit.Task;
      }
    }
  }
}
