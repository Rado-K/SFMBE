namespace SFMBE.Client.Features.Items
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class ItemState
  {
    internal class UnequipItemHandler : BaseHandler<UnequipItemAction>
    {
      public UnequipItemHandler(IStore store) : base(store)
      {
      }

      public override async Task<Unit> Handle(UnequipItemAction action, CancellationToken cancellationToken)
      {
        // this.GearState.Gear.Remove(action.Item);
        // this.BagState.Bag.Add(action.Item);

        // var characterId = this.CharacterState.Character.Data.Id;
        // await this.itemsRepository.Unequip(new UnequipItemRequest { CharacterId = characterId, ItemId = action.Item.Id });

        return await Unit.Task;
      }
    }
  }
}
