namespace SFMBE.Client.Features.EventStream
{
  using System.Collections.Generic;

  public partial class EventStream
  {
    public IReadOnlyList<string> Events => this.EventStreamState.Events;
  }
}
