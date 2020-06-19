﻿namespace SFMBE.Client.Features.Character
{
  using SFMBE.Client.Features.Bag;
  using SFMBE.Client.Features.Gear;
  using System.Threading.Tasks;

  public partial class Character
  {
    private string characterName;

    protected override async Task OnInitializedAsync()
    {
      if (this.CharacterState.Character is null || this.CharacterState.Character.Data is null)
      {
        await this.Mediator.Send(new CharacterState.FetchCharacterAction());
        await this.Mediator.Send(new GearState.FetchGearAction());
        await this.Mediator.Send(new BagState.FetchBagAction());
      }
    }

    private async Task CreateCharacter()
    {
      await this.Mediator.Send(new CharacterState.CreateCharacterAction { CharacterName = this.characterName });
    }
  }
}