namespace SFMBE.Client.Features.Base
{
  using BlazorState;
  using SFMBE.Client.Features.Character;

  internal abstract class BaseHandler<TAction> : ActionHandler<TAction>
    where TAction : IAction
    {
      protected CharacterState CharacterState => this.Store.GetState<CharacterState>();

      protected BaseHandler(IStore store) : base(store) { }
    }
}