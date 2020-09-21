namespace SFMBE.Client.Features.Base
{
  using BlazorState;

  internal abstract class BaseHandler<TAction> : ActionHandler<TAction>
    where TAction : IAction
  {
    protected BaseHandler(IStore store) : base(store) { }
  }
}
