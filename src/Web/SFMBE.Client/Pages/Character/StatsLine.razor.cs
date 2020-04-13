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

    [ParameterAttribute]
    public CharacterInfo Info { get; set; }

    private void Decreased()
    {
      --this.Value;

      this.StateHasChanged();
    }

    private void Increase()
    {
      ++this.Value;

      this.StateHasChanged();
    }

    public void UpdateValue(int value)
    {
      Console.WriteLine("UpdateValue() statsLine");
      this.Value = value;
    }

    protected override void OnAfterRender(bool firstRender)
    {
      if (firstRender)
      {
        Console.WriteLine("OnAfterRender");
        this.Info.AddToParent(this);
      }
    }
  }
}
