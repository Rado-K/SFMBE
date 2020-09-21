namespace SFMBE.Client.Features.Character
{
  using Microsoft.AspNetCore.Components;
  using System.Threading.Tasks;

  public partial class StatsLine
  {
    [Parameter]
    public string Type { get; set; }

    [Parameter]
    public int Value { get; set; }

    [Parameter]
    public EventCallback<int> Update { get; set; }

    private async Task Decreased()
    {
      await this.Update.InvokeAsync(--this.Value);
    }

    private async Task Increased()
    {
      await this.Update.InvokeAsync(++this.Value);
    }
  }
}
