namespace SFMBE.Client.Features.Gears
{
  using System.Collections.Generic;
  using System.Linq;
  using BlazorState;
  using SFMBE.Shared.Items.Queries;

  internal partial class GearsState : State<GearsState>
  {
    public IList<GetItemQueryResponse> Gear { get; set; }

    public override void Initialize() { }

    public GetItemQueryResponse AddItem(GetItemQueryResponse item)
    {
      var existsSecondItem = this.Gear.FirstOrDefault(x => x.ItemType == item.ItemType && x.Id != item.Id);

      this.Gear.Add(item);
      if (existsSecondItem != null)
      {
        this.Gear.Remove(existsSecondItem);

        return existsSecondItem;
      }
      // TODO: Repair default
      return default;
    }
  }
}