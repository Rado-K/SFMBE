namespace SFMBE.Client.Features.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Repositories.Characters;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Character.Get;
  using SFMBE.Shared.Character.Update;
  using System.Threading.Tasks;

  public partial class CharacterInfo
  {
    [Parameter]
    public GetCharacterResponse Character { get; set; }

    [Inject]
    public ICharactersRepository CharactersRepository { get; set; }

    private UpdateCharacter characterUpdateModel;

    protected override void OnInitialized()
    {
      this.characterUpdateModel = this.Character.To<UpdateCharacter>();
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
      //TODO: Use Mediator!
      await this.CharactersRepository.UpdateCharacter(this.characterUpdateModel);
    }
  }
}
