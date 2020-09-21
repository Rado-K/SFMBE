namespace SFMBE.Client.Features.Characters
{
  using System.Threading.Tasks;

  public partial class Character
  {
    private string characterName = string.Empty;

    protected override async Task OnInitializedAsync()
    {
      if (this.CharactersState.Character is null)
      {
        await this.Mediator.Send(new CharacterState.FetchCharacterAction());
      }
    }

    private async Task CreateCharacter()
    {
      await this.Mediator.Send(new CharacterState.CreateCharacterAction { CharacterName = this.characterName });

      //TODO: Remove null.
      this.CharactersState.Character = null;
      await this.OnInitializedAsync();
    }
  }
}
