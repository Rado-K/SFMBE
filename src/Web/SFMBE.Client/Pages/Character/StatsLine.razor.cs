namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using System;

  public partial class StatsLine
  {
    [Parameter]
    public string Type { get; set; }

    [Parameter]
    public int Value { get; set; }

    [Parameter] public EventCallback<int> Update{ get; set; }

    private void Decreased()
    {
      this.Update.InvokeAsync(--this.Value);
    }

    private void Increased()
    {
      this.Update.InvokeAsync(++this.Value);
    }
  }
}
