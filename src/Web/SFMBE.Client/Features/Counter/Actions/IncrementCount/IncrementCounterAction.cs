namespace SFMBE.Client.Features.Counter
{
  using SFMBE.Client.Features.Base;

  internal partial class CounterState
  {
    public class IncrementCounterAction : BaseAction
    {
      public int Amount { get; set; }
    }
  }
}
