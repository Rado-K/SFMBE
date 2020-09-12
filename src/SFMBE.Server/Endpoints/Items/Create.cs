namespace SFMBE.Server.Endpoints.Items
{
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data.Models;
  using SFMBE.Data.Repositories;
  using SFMBE.Shared.Items.Commands;
  using System;
  using System.Threading;
  using System.Threading.Tasks;

  public class Create : BaseAsyncEndpoint<CreateItemCommand, int>
  {
    private readonly IAsyncRepository<Item> itemRepository;

    public Create(IAsyncRepository<Item> repository)
    {
      this.itemRepository = repository;
    }

    [Authorize]
    [HttpPost("api/Items/Create")]
    public override async Task<ActionResult<int>> HandleAsync(CreateItemCommand createItemCommand, CancellationToken cancellationToken = default)
    {
      var rnd = new Random();

      var averageStats = createItemCommand.Stamina + createItemCommand.Stamina + createItemCommand.Stamina + createItemCommand.Agility + createItemCommand.Level;

      var item = new Item();

      if (createItemCommand.VendorId is null)
      {
        item.ItemType = Enum.Parse<ItemType>(createItemCommand.ItemType);
        item.Level = rnd.Next(createItemCommand.Level - 1, createItemCommand.Level + 1);
        item.Stamina = rnd.Next(0, createItemCommand.Stamina / 2);
        item.Strength = rnd.Next(0, createItemCommand.Strength / 2);
        item.Agility = rnd.Next(0, createItemCommand.Agility / 2);
        item.Intelligence = rnd.Next(0, createItemCommand.Intelligence / 2);
        item.Price = rnd.Next(averageStats, averageStats * rnd.Next(1, 4));
        item.CharacterId = createItemCommand.CharacterId;
      }
      else
      {
        item.ItemType = Enum.Parse<ItemType>(createItemCommand.ItemType);
        item.Level = rnd.Next(createItemCommand.Level - 1, createItemCommand.Level + 1);
        item.Stamina = rnd.Next(0, createItemCommand.Stamina / 2);
        item.Strength = rnd.Next(0, createItemCommand.Strength / 2);
        item.Agility = rnd.Next(0, createItemCommand.Agility / 2);
        item.Intelligence = rnd.Next(0, createItemCommand.Intelligence / 2);
        item.Price = rnd.Next(averageStats, averageStats * rnd.Next(1, 4));
        item.VendorId = createItemCommand.VendorId;
      }

      await this.itemRepository.AddAsync(item);

      return this.Ok(item.Id);
    }
  }
}
