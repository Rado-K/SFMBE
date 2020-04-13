namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Shared.Character;

  public partial class CharacterInfo
  {
    [Parameter]
    public CharacterResponseModel Character { get; set; }
  }
}
