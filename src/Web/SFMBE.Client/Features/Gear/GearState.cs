namespace SFMBE.Client.Features.Gear
{
  using BlazorState;
  using SFMBE.Shared.Items;
  using System.Collections.Generic;
  using System.Linq;

  internal partial class GearState : State<GearState>
  {
    public List<ItemResponseModel> Gear { get; set; }

    public override void Initialize() { }

    public ItemResponseModel AddItem(ItemResponseModel item)
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
