namespace SFMBE.Client.Features.Base
{
  using BlazorState;
  using SFMBE.Client.Features.Character;
  using SFMBE.Client.Features.Items;
  using SFMBE.Client.Features.Vendor;

  internal abstract class BaseHandler<TAction> : ActionHandler<TAction>
    where TAction : IAction
    {
      protected CharacterState CharacterState => this.Store.GetState<CharacterState>();

      protected VendorsState VendorState => this.Store.GetState<VendorsState>();

      protected ItemsState ItemsState => this.Store.GetState<ItemsState>();

      protected BaseHandler(IStore store) : base(store) { }
    }
}