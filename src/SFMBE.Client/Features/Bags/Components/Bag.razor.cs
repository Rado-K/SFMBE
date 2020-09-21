namespace SFMBE.Client.Features.Bags
{
  using System.Collections.Generic;
  using System;
  using SFMBE.Shared.Items.Queries;

  public partial class Bag
  {
    private IList<GetItemQueryResponse> Items => this.BagsState.Bag;

    private int BoardRows
      => this.Items is null ?
      0 : (int) Math.Ceiling((decimal) this.Items.Count / 3);
  }
}