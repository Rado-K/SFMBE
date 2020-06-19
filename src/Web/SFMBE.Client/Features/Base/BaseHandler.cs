namespace SFMBE.Client.Features.Base
{
  using BlazorState;
  using SFMBE.Client.Features.Bag;
  using SFMBE.Client.Features.Character;
  using SFMBE.Client.Features.Counter;
  using SFMBE.Client.Features.EventStream;
  using SFMBE.Client.Features.Gear;
  using SFMBE.Client.Features.Items;

  internal abstract class BaseHandler<TAction> : ActionHandler<TAction>
    where TAction : IAction
  {
    protected CounterState CounterState => this.Store.GetState<CounterState>();
    protected EventStreamState EventStreamState => this.Store.GetState<EventStreamState>();
    protected CharacterState CharacterState => this.Store.GetState<CharacterState>();
    protected BagState BagState => this.Store.GetState<BagState>();
    protected GearState GearState => this.Store.GetState<GearState>();
    protected ItemState ItemsState => this.Store.GetState<ItemState>();

    protected BaseHandler(IStore store) : base(store) { }
  }
}
