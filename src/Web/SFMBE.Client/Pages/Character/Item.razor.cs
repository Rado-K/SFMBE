namespace SFMBE.Client.Pages.Character
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Shared.Items;
  using System.Threading.Tasks;

  public partial class Item
  {
    [Parameter]
    public ItemResponseModel Model { get; set; }

    [Parameter]
    public string ClassName { get; set; }


    private async Task Equip()
    {
      var item = this.Model;

      await this.BagState.Unequip(item);
      await this.GearState.Equip(item);
    }

    private async Task Unequip()
    {
      var item = this.Model;

      await this.GearState.Unequip(item);
      await this.BagState.Equip(item);
    }
  }
}
