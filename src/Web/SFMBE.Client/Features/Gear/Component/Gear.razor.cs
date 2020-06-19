namespace SFMBE.Client.Features.Gear
{
  using SFMBE.Shared.Items.Get;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public partial class Gear
  {
    private List<GetItemResponse> Items => this.GearState.Gear;

    private int BoardRows
      => this.Items is null
        ? 0 : (int)Math.Ceiling((decimal)this.Items.Count / 3);

    private List<GetItemResponse> OrderItems()
    {
      var items = this.Items;

      var euquipetItems = items.Where(x => x.ItemType != "Empty").Count();

      if (euquipetItems == 0)
      {
        return items.Where(x => x.ItemType != "Empty").ToList();
      }

      var emptyItem = new GetItemResponse();

      if (euquipetItems != 0 && items.Count > 9)
      {
        emptyItem = items.FirstOrDefault(x => x.ItemType == "Empty");

        items.Remove(emptyItem);
      }
      else
      {
        for (var i = 0; i < 9 - euquipetItems; i++)
        {
          if (items.Count == 9)
          {
            break;
          }

          items.Add(emptyItem);
        }
      }

      var gearItemsPosition = new List<string>()
      {
        "Empty", "Head", "Empty",
        "Sword", "Chest", "Shield",
        "Empty", "Boots", "Empty",
      };

      for (var i = 0; i < 9; i++)
      {
        var temp = items.FirstOrDefault(x => x.ItemType == gearItemsPosition[i]);

        if (temp == null)
        {
          continue;
        }

        var currItem = items.IndexOf(temp);
        items[currItem] = items[i];
        items[i] = temp;
      }

      return items;
    }
  }
}
