namespace SFMBE.Server.Controllers.Items.Unequip
{
  using MediatR;
  using SFMBE.Services.Data.Items;
  using SFMBE.Shared.Items.Unequip;
  using System.Threading;
  using System.Threading.Tasks;

  public class UnequipItemHandler : IRequestHandler<UnequipItemRequest, Unit>
  {
    private readonly IItemsService itemsService;

    public UnequipItemHandler(IItemsService itemsService)
    {
      this.itemsService = itemsService;
    }

    public async Task<Unit> Handle(UnequipItemRequest request, CancellationToken cancellationToken)
    {
      await this.itemsService.Unequip(request.ItemId);

      return await Unit.Task;
    }
  }
}
