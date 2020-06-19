namespace SFMBE.Client.Features.Items
{
  using SFMBE.Client.Features.Base;
  using SFMBE.Shared.Items;

  internal partial class ItemState
  {
    public class EquipItemAction : BaseAction
    {
      public ItemResponseModel Item { get; set; }
    }
  }
}
