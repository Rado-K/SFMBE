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
        await this.Mediator.Send(new CharactersState.FetchCharacterAction());
      }
      this.checkForCharacter = true;
    }

    private async Task CreateCharacter()
    {
      await this.Mediator.Send(new CharactersState.CreateCharacterAction { CharacterName = this.characterName });
      
      await this.OnInitializedAsync();
    }
  }
}