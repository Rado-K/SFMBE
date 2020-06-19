namespace SFMBE.Client.Features.Bag
{
  using SFMBE.Shared.Items.Get;
  using System;
  using System.Collections.Generic;

  public partial class Bag
  {
    private List<GetItemResponse> Items => this.BagState.Bag;

    private int BoardRows
    => this.Items is null
        ? 0 : (int) Math.Ceiling((decimal)this.Items.Count / 3);
  }
}
