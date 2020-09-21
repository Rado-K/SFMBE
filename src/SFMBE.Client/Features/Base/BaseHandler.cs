namespace SFMBE.Client.Features.Base
{
  using BlazorState;
  using SFMBE.Client.Features.Bags;
  using SFMBE.Client.Features.Characters;
  using SFMBE.Client.Features.Gears;
  using SFMBE.Client.Features.Items;
  using SFMBE.Client.Features.Vendor;

  internal abstract class BaseHandler<TAction> : ActionHandler<TAction>
    where TAction : IAction
    {
      protected CharactersState CharacterState => this.Store.GetState<CharactersState>();

      protected VendorsState VendorState => this.Store.GetState<VendorsState>();

      protected ItemsState ItemsState => this.Store.GetState<ItemsState>();

      protected BagsState BagsState => this.Store.GetState<BagsState>();

      protected GearsState GearsState => this.Store.GetState<GearsState>();

      protected BaseHandler(IStore store) : base(store) { }
    }
}