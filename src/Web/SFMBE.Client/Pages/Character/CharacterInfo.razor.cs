namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Character;
  using SFMBE.Shared.Character;
  using System;

  public partial class CharacterInfo
  {
    [Parameter]
    public CharacterResponseModel Character { get; set; }

    [Inject] public ICharactersRepository CharactersRepository { get; set; }

    public void AddToParent(StatsLine stats)
    {
      Console.WriteLine("Befor Update method in info");
      this.Update(stats, stats.Value);
      Console.WriteLine("after Update method in info");

      this.CharactersRepository.UpdateCharacter();
      this.StateHasChanged();
    }

    private void Update(StatsLine item, int value)
    {
      Console.WriteLine("In update method");
      item.UpdateValue(value);
      Console.WriteLine("end update method");
    }
  }
}
