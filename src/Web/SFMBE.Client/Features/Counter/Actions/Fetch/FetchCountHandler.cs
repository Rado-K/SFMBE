namespace SFMBE.Client.Features.Counter
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using System;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class CounterState
  {
    internal class FetchCountHandler : BaseHandler<FetchCountAction>
    {
      public FetchCountHandler(IStore store) : base(store)
      {
      }

      public override Task<Unit> Handle(FetchCountAction fetchCountAction, CancellationToken cancellationToken)
      {
        this.CounterState.Count += 12;
        return Unit.Task;
      }
    }
  }
}
