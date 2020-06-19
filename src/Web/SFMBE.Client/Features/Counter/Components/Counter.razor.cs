namespace SFMBE.Client.Features.Counter.Components
{
  using System.Threading.Tasks;

  public partial class Counter
  {
    private async Task IncrementCount()
    {
      await this.Mediator.Send(new CounterState.IncrementCounterAction { Amount = 5 });
    }
  }
}
