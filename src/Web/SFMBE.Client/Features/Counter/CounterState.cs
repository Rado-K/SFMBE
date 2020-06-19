namespace SFMBE.Client.Features.Counter
{
  using BlazorState;

  internal partial class CounterState : State<CounterState>
  {
    public int Count { get; private set; }

    public override void Initialize() { }
  }
}
