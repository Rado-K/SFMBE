namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Characters;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Character;

  public partial class CharacterInfo
  {
    [Parameter]
    public CharacterResponseModel Character { get; set; }

    [Inject] public ICharactersRepository CharactersRepository { get; set; }

    private CharacterUpdateModel characterUpdateModel = new CharacterUpdateModel();

    protected override void OnInitialized()
    {
      this.characterUpdateModel = this.Character.To<CharacterUpdateModel>();
    }

    private void UpdateStamina(int value)
    {
      this.characterUpdateModel.Stamina = value;

      this.UpdateCharacter();
    }

    private void UpdateStrength(int value)
    {
      this.characterUpdateModel.Strength = value;

      this.UpdateCharacter();
    }

    private void UpdateAgility(int value)
    {
      this.characterUpdateModel.Agility = value;

      this.UpdateCharacter();
    }

    private void UpdateIntelligence(int value)
    {
      this.characterUpdateModel.Intelligence = value;

      this.UpdateCharacter();
    }

    private void UpdateCharacter()
    {
      this.CharactersRepository.UpdateCharacter(this.characterUpdateModel);
    }
  }
}
