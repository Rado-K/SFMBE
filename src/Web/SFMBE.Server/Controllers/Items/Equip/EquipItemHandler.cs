namespace SFMBE.Server.Controllers.Items.Equip
{
  using MediatR;
  using SFMBE.Services.Data.Items;
  using SFMBE.Shared.Items.Equip;
  using System.Threading;
  using System.Threading.Tasks;

  public class EquipItemHandler : IRequestHandler<EquipItemRequest, Unit>
  {
    private readonly IItemsService itemsService;

    public EquipItemHandler(IItemsService itemsService)
    {
      this.itemsService = itemsService;
    }

    public async Task<Unit> Handle(EquipItemRequest request, CancellationToken cancellationToken)
    {
      await this.itemsService.Equip(request.ItemId);

      return await Unit.Task;
    }
  }
}
