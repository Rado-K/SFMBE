namespace SFMBE.Client.Features.Bag
{
  using SFMBE.Shared.Items;
  using System;
  using System.Collections.Generic;

  public partial class Bag
  {
    private List<ItemResponseModel> Items => this.BagState.Bag;

    private int BoardRows
    => this.Items is null
        ? 0 : (int) Math.Ceiling((decimal)this.Items.Count / 3);
  }
}
