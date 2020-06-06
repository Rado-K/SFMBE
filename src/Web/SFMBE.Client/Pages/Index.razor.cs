namespace SFMBE.Client.Pages
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Characters;
  using SFMBE.Shared;
  using SFMBE.Shared.Character;
  using System.Threading.Tasks;

  public partial class Index
  {
    [Inject] public ICharactersRepository CharactersRepository { get; set; }

    private static ApiResponse<CharacterResponseModel> character;

    private readonly CharacterRequestModel characterRequestModel = new CharacterRequestModel();

    protected override async Task OnInitializedAsync()
    {
      if (character == null)
      {
        character = await this.CharactersRepository.GetCharacter();
        await this.BagState.Initialize();
        await this.GearState.Initialize();
      }
    }

    private async Task CreateCharacter()
    {
      var characterId = await this.CharactersRepository.CreateCharacter(this.characterRequestModel.CharacterName);

      if (characterId.IsOk)
      {
        character = await this.CharactersRepository.GetCharacter();
      }
    }
  }
}