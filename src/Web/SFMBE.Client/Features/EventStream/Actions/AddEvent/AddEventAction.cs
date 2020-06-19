namespace SFMBE.Client.Features.EventStream
{
  using SFMBE.Client.Features.Base;

  internal partial class EventStreamState
  {
    public class AddEventAction : BaseAction
    {
      public string Message { get; set; }
    }
  }
}
