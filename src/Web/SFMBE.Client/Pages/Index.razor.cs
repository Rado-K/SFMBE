namespace SFMBE.Client.Pages
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Characters;
  using SFMBE.Shared;
  using SFMBE.Shared.Character;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  public partial class Index
  {
    [Inject] public ICharactersRepository CharactersRepository { get; set; }

    private List<string> bagItems;

    private List<string> gearItems;

    private ApiResponse<CharacterResponseModel> character;
    private readonly CharacterRequestModel characterRequestModel = new CharacterRequestModel();

    protected override async Task OnInitializedAsync()
    {
      this.character = await this.CharactersRepository.GetCharacter();

      this.gearItems = new List<string>
      {
        "chest1", "boots1", "head1","sword1","shield1",
        "chest1", "boots1", "head1","sword1",
      };

      this.bagItems = new List<string>
        {
          "chest1", "boots1", "head1","sword1","shield1",
          "chest1", "boots1", "head1","sword1","shield1",
          "chest1", "boots1", "head1","sword1","shield1",
          "chest1", "boots1", "head1","sword1","shield1",
          "chest1", "boots1", "head1","sword1","shield1",
          "chest1", "boots1", "head1","sword1","shield1",
        };
    }

    private async Task CreateCharacter()
    {
      var characterId = await this.CharactersRepository.CreateCharacter(this.characterRequestModel.CharacterName);

      if (characterId.IsOk)
      {
        this.character = await this.CharactersRepository.GetCharacter(characterId.Data.Id);
      }
    }
  }
}