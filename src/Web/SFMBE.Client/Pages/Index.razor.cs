namespace SFMBE.Client.Pages
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public partial class Index
  {
    //private static readonly string bag = "bag";
    //private readonly string gear = "gear";
    private List<string> bagItems;

    private List<string> gearItems;

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
  }
}