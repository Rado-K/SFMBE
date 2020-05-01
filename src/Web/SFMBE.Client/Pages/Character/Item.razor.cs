namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Gears;
  using SFMBE.Shared.Items;
  using System.Threading.Tasks;

  public partial class Item
  {
    [Parameter]
    public ItemResponseModel Model { get; set; }

    [Parameter]
    public string ClassName { get; set; }

    [CascadingParameter]
    public Board Board { get; set; }

    private async Task Equip()
    {
      //await this.Board.Equip(this.Model.Id);
    }

    private async Task Unequip()
    {
      //await this.Board.Unequip(this.Model.Id);
    }
  }
}
