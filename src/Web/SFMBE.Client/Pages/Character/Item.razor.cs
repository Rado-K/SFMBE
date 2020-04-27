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

    public Board Board { get; set; }

    [CascadingParameter]
    public IGearsRepository GearsRepository { get; set; }

    private async Task Equip()
    {
      await this.GearsRepository.Equip(this.Model.Id);

      this.StateHasChanged();
    }

    private async Task Unequip()
    {
      await this.GearsRepository.Unequip(this.Model.Id);

      this.StateHasChanged();
    }
  }
}
