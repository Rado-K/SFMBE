namespace SFMBE.Client.Features.Base.Components
{
  using BlazorState.Pipeline.ReduxDevTools;
  using System.Threading.Tasks;

  public class BaseComponent : BlazorStateDevToolsComponent
  {
    
    internal async Task ChangeState<T>()
    {
      await this.InvokeAsync(this.Subscriptions.ReRenderSubscribers<T>);
    }
  }
}
