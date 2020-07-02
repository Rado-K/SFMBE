namespace SFMBE.Client.Features.Items
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Repositories.Gears;
  using SFMBE.Shared.Items.Unequip;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class ItemState
  {
    internal class UnequipItemHandler : BaseHandler<UnequipItemAction>
    {
      private readonly IGearsRepository gearsRepository;

      public UnequipItemHandler(IGearsRepository gearsRepository, IStore store) : base(store)
      {
        this.gearsRepository = gearsRepository;
      }

      public override async Task<Unit> Handle(UnequipItemAction action, CancellationToken cancellationToken)
      {
        this.GearState.Gear.Remove(action.Item);
        this.BagState.Bag.Add(action.Item);

        var characterId = this.CharacterState.Character.Data.Id;
        await this.gearsRepository.Unequip(new UnequipItemRequest { CharacterId =characterId, ItemId = action.Item.Id });

        return await Unit.Task;
      }
    }
  }
}
