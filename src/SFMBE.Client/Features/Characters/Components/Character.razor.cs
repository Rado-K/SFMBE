namespace SFMBE.Client.Features.Characters
{
  using System.Threading.Tasks;

  public partial class Character
  {
    private string characterName = string.Empty;

    private bool checkForCharacter = false;

    protected override async Task OnInitializedAsync()
    {
      if (this.CharactersState.Character is null)
      {
        this.checkForCharacter = true;
        await this.Mediator.Send(new CharactersState.FetchCharacterAction());
      }
    }

    private async Task CreateCharacter()
    {
      await this.Mediator.Send(new CharactersState.CreateCharacterAction { CharacterName = this.characterName });
      this.checkForCharacter = false;
      await this.OnInitializedAsync();
    }
  }
}
