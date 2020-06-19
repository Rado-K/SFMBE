namespace SFMBE.Client.Features.Bag
{
  using BlazorState;
  using SFMBE.Shared.Items.Get;
  using System.Collections.Generic;

  internal partial class BagState : State<BagState>
  {
    public List<GetItemResponse> Bag { get; set; }

    public override void Initialize() { }
  }
}
