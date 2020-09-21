namespace SFMBE.Client.Features.Base
{
  using BlazorState;
  using SFMBE.Client.Features.Character;
  using SFMBE.Client.Features.Vendor;

  internal abstract class BaseHandler<TAction> : ActionHandler<TAction>
    where TAction : IAction
    {
      protected CharacterState CharacterState => this.Store.GetState<CharacterState>();

      protected VendorState VendorState => this.Store.GetState<VendorState>();

      protected BaseHandler(IStore store) : base(store) { }
    }
}