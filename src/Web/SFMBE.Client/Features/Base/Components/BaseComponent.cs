namespace SFMBE.Client.Features.Base.Components
{
  using BlazorState.Pipeline.ReduxDevTools;
  using SFMBE.Client.Features.Bag;
  using SFMBE.Client.Features.Character;
  using SFMBE.Client.Features.Counter;
  using SFMBE.Client.Features.EventStream;
  using SFMBE.Client.Features.Gear;
  using SFMBE.Client.Features.Items;
  using System.Threading.Tasks;

  public class BaseComponent : BlazorStateDevToolsComponent
  {
    internal CounterState CounterState => this.GetState<CounterState>();
    internal EventStreamState EventStreamState => this.GetState<EventStreamState>();
    internal BagState BagState => this.GetState<BagState>();
    internal CharacterState CharacterState => this.GetState<CharacterState>();
    internal GearState GearState => this.GetState<GearState>();
    internal ItemState ItemsState => this.GetState<ItemState>();

    internal async Task ChangeState<T>()
    {
      await this.InvokeAsync(this.Subscriptions.ReRenderSubscribers<T>);
    }
  }
}
