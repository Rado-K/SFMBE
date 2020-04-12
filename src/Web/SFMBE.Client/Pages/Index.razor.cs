namespace SFMBE.Client.Pages
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Character;
  using SFMBE.Shared;
  using SFMBE.Shared.Character;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public partial class Index
  {
    [Inject] public ICharactersRepository CharactersRepository { get; set; }

    private List<string> bagItems;

    private List<string> gearItems;

    private ApiResponse<CharacterResponseModel> character;
    private CharacterRequestModel model = new CharacterRequestModel();
    private string charachterName = string.Empty;

    protected override async Task OnInitializedAsync()
    {

      await Task.Delay(0);


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

    private void log()
    {
      this.charachterName = "maa";
      Console.WriteLine(this.charachterName);
    }
  }
}