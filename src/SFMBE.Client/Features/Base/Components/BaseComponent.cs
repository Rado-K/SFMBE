namespace SFMBE.Client.Features.Base.Components
{
  using BlazorState.Pipeline.ReduxDevTools;
  using SFMBE.Client.Features.Character;
  using SFMBE.Client.Features.Vendor;
  using System.Threading.Tasks;

  public class BaseComponent : BlazorStateDevToolsComponent
  {
    internal CharacterState CharacterState => this.GetState<CharacterState>();

    internal VendorState VendorState => this.GetState<VendorState>();

    internal async Task ChangeState<T>()
    {
      await this.InvokeAsync(this.Subscriptions.ReRenderSubscribers<T>);
    }
  }
}
