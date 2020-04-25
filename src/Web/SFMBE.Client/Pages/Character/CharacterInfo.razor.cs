﻿namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Characters;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Character;
  using System.Threading.Tasks;

  public partial class CharacterInfo
  {
    [Parameter]
    public CharacterResponseModel Character { get; set; }

    [Inject]
    public ICharactersRepository CharactersRepository { get; set; }

    private CharacterUpdateModel characterUpdateModel = new CharacterUpdateModel();

    protected override void OnInitialized()
    {
      this.characterUpdateModel = this.Character.To<CharacterUpdateModel>();
    }

    private async Task UpdateStamina(int value)
    {
      this.characterUpdateModel.Stamina = value;

      await this.UpdateCharacter();
    }

    private async Task UpdateStrength(int value)
    {
      this.characterUpdateModel.Strength = value;

      await this.UpdateCharacter();
    }

    private async Task UpdateAgility(int value)
    {
      this.characterUpdateModel.Agility = value;

      await this.UpdateCharacter();
    }

    private async Task UpdateIntelligence(int value)
    {
      this.characterUpdateModel.Intelligence = value;

      await this.UpdateCharacter();
    }

    private async Task UpdateCharacter()
    {
      await this.CharactersRepository.UpdateCharacter(this.characterUpdateModel);
    }
  }
}
