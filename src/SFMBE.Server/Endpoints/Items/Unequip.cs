namespace SFMBE.Server.Endpoints.Items
{
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data.Models;
  using SFMBE.Data.Repositories;
  using SFMBE.Shared.Items.Commands;

  public class Unequip : BaseAsyncEndpoint
  {
    private readonly IAsyncRepository<Item> repository;

    public Unequip(IAsyncRepository<Item> repository)
    {
      this.repository = repository;
    }

    [Authorize]
    [HttpPut("api/Items/Unequip")]
    public async Task<IActionResult> HandleAsync(UnquipItemCommand equipItemCommand)
    {
      var item = await this.repository.GetByIdAsync(equipItemCommand.ItemId);
      item.IsEquip = EquipType.InBag;
      await this.repository.UpdateAsync(item);
      return this.Ok();
    }
  }
}
