namespace SFMBE.Client.Features.Bag
{
  using BlazorState;
  using SFMBE.Shared.Items;
  using System.Collections.Generic;

  internal partial class BagState : State<BagState>
  {
    public List<ItemResponseModel> Bag { get; set; }

    public override void Initialize() { }
  }
}
