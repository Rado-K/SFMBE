namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Characters;
  using SFMBE.Shared.Character;

  public partial class CharacterInfo
  {
    [Parameter]
    public CharacterResponseModel Character { get; set; }

    [Inject] public ICharactersRepository CharactersRepository { get; set; }

    private void UpdateStamina(int value)
    {
      this.Character.Stamina = value;

      this.UpdateCharacter();
    }

    private void UpdateStrength(int value)
    {
      this.Character.Strength = value;

      this.UpdateCharacter();
    }

    private void UpdateAgility(int value)
    {
      this.Character.Agility = value;

      this.UpdateCharacter();
    }

    private void UpdateIntelligence(int value)
    {
      this.Character.Intelligence = value;

      this.UpdateCharacter();
    }

    private void UpdateCharacter()
    {
      this.CharactersRepository.UpdateCharacter(this.Character);
    }
  }
}
