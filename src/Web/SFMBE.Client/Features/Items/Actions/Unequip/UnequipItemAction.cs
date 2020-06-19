namespace SFMBE.Client.Features.Items
{
  using SFMBE.Client.Features.Base;
  using SFMBE.Shared.Items.Get;

  internal partial class ItemState
  {
    public class UnequipItemAction : BaseAction
    {
      public GetItemResponse Item { get; set; }
    }
  }
}
