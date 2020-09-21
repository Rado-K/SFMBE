namespace SFMBE.Client.Features.Items
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class ItemState
  {
    internal class EquipItemHandler : BaseHandler<EquipItemAction>
    {
      public EquipItemHandler(IStore store) : base(store)
      {
      }

      public override async Task<Unit> Handle(EquipItemAction action, CancellationToken cancellationToken)
      {
        // this.BagState.Bag.Remove(action.Item);

        // var unequipItem = this.GearState.AddItem(action.Item);

        // var characterId = this.CharacterState.Character.Data.Id;
        // if (unequipItem != null)
        // {
        //   this.BagState.Bag.Add(unequipItem);
        //   await this.itemsRepository.Unequip(new UnequipItemRequest { CharacterId = characterId, ItemId = unequipItem.Id });
        // }

        // await this.itemsRepository.Equip(new EquipItemRequest { CharacterId = characterId, ItemId = action.Item.Id });

        return await Unit.Task;
      }
    }
  }
}
