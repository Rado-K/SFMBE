namespace SFMBE.Server.Endpoints.Items
{
  using System.Threading.Tasks;
  using System.Threading;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Repositories.Items;
  using SFMBE.Shared.Items.Commands;

  public class Create : BaseAsyncEndpoint<CreateItemCommand, int>
  {
    private readonly IItemsRepository itemsRepository;

    public Create(IItemsRepository itemsRepository)
    {
      this.itemsRepository = itemsRepository;
    }

    [Authorize]
    [HttpPost("api/Items/Create")]
    public override async Task<ActionResult<int>> HandleAsync(CreateItemCommand createItemCommand, CancellationToken cancellationToken = default)
    {
      var itemId = await this.itemsRepository.Create(createItemCommand);

      return this.Ok(itemId);
    }
  }
}