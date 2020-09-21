namespace SFMBE.Client.Features.Items
{
  using SFMBE.Client.Features.Base;
  using SFMBE.Shared.Items.Queries;

  internal partial class ItemState
  {
    public class EquipItemAction : BaseAction
    {
      public GetItemQueryResponse Item { get; set; }
    }
  }
}
