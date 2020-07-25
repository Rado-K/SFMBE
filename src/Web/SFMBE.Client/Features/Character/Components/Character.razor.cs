namespace SFMBE.Client.Features.Character
{
  using System.Threading.Tasks;

  public partial class Character
  {
    private string characterName = string.Empty;

    protected override async Task OnInitializedAsync()
    {
      if (this.CharacterState.Character is null || this.CharacterState.Character.Data is null)
      {
        await this.Mediator.Send(new CharacterState.FetchCharacterAction());
      }
    }

    private async Task CreateCharacter()
    {
      await this.Mediator.Send(new CharacterState.CreateCharacterAction { CharacterName = this.characterName });

      //TODO: Remove null.
      this.CharacterState.Character = null;
      await this.OnInitializedAsync();
    }
  }
}
