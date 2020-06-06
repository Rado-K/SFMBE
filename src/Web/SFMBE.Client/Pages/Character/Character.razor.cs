namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Shared.Character;

  public partial class Character
  {
    [Parameter] public CharacterResponseModel CharacterModel { get; set; }
  }
}
