namespace SFMBE.Client.Pages
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Bags;
  using SFMBE.Client.Respository.Characters;
  using SFMBE.Client.Respository.Gears;
  using SFMBE.Shared;
  using SFMBE.Shared.Bags;
  using SFMBE.Shared.Character;
  using SFMBE.Shared.Gear;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public partial class Index
  {
    [Inject] public ICharactersRepository CharactersRepository { get; set; }

    private ApiResponse<CharacterResponseModel> character;

    private readonly CharacterRequestModel characterRequestModel = new CharacterRequestModel();

    protected override async Task OnInitializedAsync()
    {
      this.character = await this.CharactersRepository.GetCharacter();
    }

    private async Task CreateCharacter()
    {
      var characterId = await this.CharactersRepository.CreateCharacter(this.characterRequestModel.CharacterName);

      if (characterId.IsOk)
      {
        this.character = this.character = await this.CharactersRepository.GetCharacter();
      }
    }
  }
}