namespace SFMBE.Server.Endpoints.Items
{
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Repositories.Items;
  using SFMBE.Shared.Items.Commands;

  public class Equip : BaseAsyncEndpoint
  {
    private readonly IItemsRepository itemsRepository;

    public Equip(IItemsRepository itemsRepository)
    {
      this.itemsRepository = itemsRepository;
    }

    [Authorize]
    [HttpPut("api/Items/Equip")]
    public async Task<IActionResult> HandleAsync(EquipItemCommand equipItemCommand)
    {
      await this.itemsRepository.Equip(equipItemCommand);

      return this.Ok();
    }
  }
}