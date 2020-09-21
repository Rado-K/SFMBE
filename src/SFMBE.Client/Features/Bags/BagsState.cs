namespace SFMBE.Client.Features.Bags
{
  using BlazorState;
  using SFMBE.Shared.Items.Queries;
  using System.Collections.Generic;

  internal partial class BagsState : State<BagsState>
  {
    public IList<GetItemQueryResponse> Bag { get; set; }

    public override void Initialize() { }
  }
}
