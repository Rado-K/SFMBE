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

    private ApiResponse<CharacterResponseModel> character;

    private readonly CharacterRequestModel characterRequestModel = new CharacterRequestModel();

    protected override async Task OnInitializedAsync()
    {
      if (character == null || character?.Data == null)
      {
        character = await this.CharactersRepository.GetCharacter();

        if (character.IsOk)
        {
          await this.BagState.Initialize();
          await this.GearState.Initialize();
        }
      }
    }

    private async Task CreateCharacter()
    {
      var characterCreatedResponse = await this.CharactersRepository.CreateCharacter(this.characterRequestModel.CharacterName);

      if (characterCreatedResponse.IsOk)
      {
        await this.OnInitializedAsync();
      }
    }
  }
}