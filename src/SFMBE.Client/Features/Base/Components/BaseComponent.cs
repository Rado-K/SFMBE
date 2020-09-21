namespace SFMBE.Client.Features.Base.Components
{
  using BlazorState.Pipeline.ReduxDevTools;
  using SFMBE.Client.Features.Characters;
  using SFMBE.Client.Features.Vendor;
  using SFMBE.Client.Features.Items;
  using System.Threading.Tasks;
  using SFMBE.Client.Features.Bags;
  using SFMBE.Client.Features.Gears;

  public class BaseComponent : BlazorStateDevToolsComponent
  {
    internal CharactersState CharactersState => this.GetState<CharactersState>();

    internal VendorsState VendorState => this.GetState<VendorsState>();

    internal BagsState BagsState => this.GetState<BagsState>();

    internal GearsState GearsState => this.GetState<GearsState>();

    internal ItemsState ItemsState => this.GetState<ItemsState>();

    internal async Task ChangeState<T>()
    {
      await this.InvokeAsync(this.Subscriptions.ReRenderSubscribers<T>);
    }
  }
}
