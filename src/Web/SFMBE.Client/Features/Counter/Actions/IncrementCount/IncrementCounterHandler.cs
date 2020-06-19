namespace SFMBE.Client.Features.Counter
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class CounterState
  {
    internal class IncrementCounterHandler : BaseHandler<IncrementCounterAction>
    {
      public IncrementCounterHandler(IStore aStore) : base(aStore) { }

      public override Task<Unit> Handle(IncrementCounterAction incrementCounterAction, CancellationToken cancellationToken)
      {
        this.CounterState.Count += incrementCounterAction.Amount;
        return Unit.Task;
      }
    }
  }
}
