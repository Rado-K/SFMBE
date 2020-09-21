namespace SFMBE.Client.Features.Items
{
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Features.Bags;
  using SFMBE.Client.Features.Gears;
  using SFMBE.Shared.Items.Queries;
  using System.Threading.Tasks;

  public partial class Item
  {
    [Parameter]
    public GetItemQueryResponse Model { get; set; }

    [Parameter]
    public string ClassName { get; set; }

    private async Task Equip()
    {
      await this.Mediator.Send(new ItemState.EquipItemAction { Item = this.Model });

      await this.ChangeStates();
    }

    private async Task Unequip()
    {
      await this.Mediator.Send(new ItemState.UnequipItemAction { Item = this.Model });

      await this.ChangeStates();
    }

    private async Task ChangeStates()
    {
      await this.ChangeState<GearsState>();
      await this.ChangeState<BagsState>();
    }
  }
}
