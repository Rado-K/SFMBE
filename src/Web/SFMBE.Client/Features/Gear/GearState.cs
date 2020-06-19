namespace SFMBE.Client.Features.Gear
{
  using BlazorState;
  using SFMBE.Shared.Items.Get;
  using System.Collections.Generic;
  using System.Linq;

  internal partial class GearState : State<GearState>
  {
    public List<GetItemResponse> Gear { get; set; }

    public override void Initialize() { }

    public GetItemResponse AddItem(GetItemResponse item)
    {
      var existsSecondItem = this.Gear.FirstOrDefault(x => x.ItemType == item.ItemType && x.Id != item.Id);

      this.Gear.Add(item);
      if (existsSecondItem != null)
      {
        this.Gear.Remove(existsSecondItem);

        return existsSecondItem;
      }

      return default;
    }
  }
}
