namespace SFMBE.Client.Features.EventStream
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class EventStreamState
  {
    internal class AddEventHandler : BaseHandler<AddEventAction>
    {
      public AddEventHandler(IStore store) : base(store) { }

      public override Task<Unit> Handle(AddEventAction addEventAction, CancellationToken cancellationToken)
      {
        EventStreamState._Events.Add(addEventAction.Message);
        return Unit.Task;
      }
    }
  }
}
