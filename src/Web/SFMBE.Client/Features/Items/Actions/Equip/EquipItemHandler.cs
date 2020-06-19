namespace SFMBE.Client.Features.Items
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Repositories.Gears;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class ItemState
  {
    internal class EquipItemHandler : BaseHandler<EquipItemAction>
    {
      private readonly IGearsRepository gearsRepository;

      public EquipItemHandler(IGearsRepository gearsRepository, IStore store) : base(store)
      {
        this.gearsRepository = gearsRepository;
      }

      public override async Task<Unit> Handle(EquipItemAction action, CancellationToken cancellationToken)
      {
        this.BagState.Bag.Remove(action.Item);
        var unequipItem = this.GearState.AddItem(action.Item);
        if (unequipItem != null)
        {
          this.BagState.Bag.Add(unequipItem);
        }
        await this.gearsRepository.Equip(action.Item.Id);

        return await Unit.Task;
      }
    }
  }
}
