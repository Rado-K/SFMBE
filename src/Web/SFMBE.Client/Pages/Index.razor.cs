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
    [Inject] public IBagsRepository BagsRepository { get; set; }
    [Inject] public IGearsRepository GearsRepository { get; set; }

    private ApiResponse<CharacterResponseModel> character;
    private ApiResponse<BagResponseModel> bag;
    private ApiResponse<GearResponseModel> gear;

    private readonly CharacterRequestModel characterRequestModel = new CharacterRequestModel();

    private IList<int> GearItems { get; set; }
    private IList<int> BagItems { get; set; }

    protected override async Task OnInitializedAsync()
    {
      this.character = await this.CharactersRepository.GetCharacter();

      if (this.character.IsOk)
      {
        this.bag = await this.BagsRepository.GetBag();
        this.BagItems = this.bag.Data.Items;

        this.gear = await this.GearsRepository.GetGear();
        this.GearItems = this.gear.Data.Items;
      }
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