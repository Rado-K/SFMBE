namespace SFMBE.Client.Features.Items
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Repositories.Items;
  using SFMBE.Shared.Items.Equip;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class ItemState
  {
    internal class EquipItemHandler : BaseHandler<EquipItemAction>
    {
      private readonly IItemsRepository itemsRepository;

      public EquipItemHandler(IItemsRepository itemsRepository, IStore store) : base(store)
      {
        this.itemsRepository = itemsRepository;
      }

      public override async Task<Unit> Handle(EquipItemAction action, CancellationToken cancellationToken)
      {
        this.BagState.Bag.Remove(action.Item);
        var unequipItem = this.GearState.AddItem(action.Item);
        if (unequipItem != null)
        {
          this.BagState.Bag.Add(unequipItem);
        }
        var characterId = this.CharacterState.Character.Data.Id;
        await this.itemsRepository.Equip(new EquipItemRequest { CharacterId = characterId, ItemId = action.Item.Id });

        return await Unit.Task;
      }
    }
  }
}
