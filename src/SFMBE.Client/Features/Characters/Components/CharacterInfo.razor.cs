namespace SFMBE.Client.Features.Characters
{
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Components;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Characters.Commands;
  using SFMBE.Shared.Characters.Queries;

  public partial class CharacterInfo
  {
    [Parameter]
    public GetCharacterQueryResponse Character { get; set; }

    private UpdateCharacterCommand characterUpdateModel;

    protected override void OnInitialized()
    {
      this.characterUpdateModel = this.Character.To<UpdateCharacterCommand>();
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
      await this.Mediator.Send(new CharactersState.UpdateCharacterAction { Character = this.characterUpdateModel });
    }
  }
}