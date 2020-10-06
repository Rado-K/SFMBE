namespace SFMBE.Server.Endpoints.Items
{
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Repositories.Items;
  using SFMBE.Shared.Items.Commands;

  public class Unequip : BaseAsyncEndpoint
  {
    private readonly IItemsRepository itemsRepository;

    public Unequip(IItemsRepository itemsRepository)
    {
      this.itemsRepository = itemsRepository;
    }

    [Authorize]
    [HttpPut("api/Items/Unequip")]
    public async Task<IActionResult> HandleAsync(UnquipItemCommand unquipItemCommand)
    {
      await this.itemsRepository.Unequip(unquipItemCommand);

      return this.Ok();
    }
  }
}