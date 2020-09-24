namespace SFMBE.Server.Endpoints.Characters
{
  using System.Threading;
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data.Models;
  using SFMBE.Data.Repositories;
  using SFMBE.Server.Services;

  public class Create : BaseAsyncEndpoint<string, int>
  {
    private readonly IAsyncRepository<Character> characterRepository;
    private readonly IUsersService usersService;

    public Create(IAsyncRepository<Character> characterRepository, IUsersService usersService)
    {
      this.characterRepository = characterRepository;
      this.usersService = usersService;
    }

    [Authorize]
    [HttpPost("api/Characters/Create")]
    public override async Task<ActionResult<int>> HandleAsync([FromBody] string name, CancellationToken cancellationToken = default)
    {
      var character = new Character { Name = name };
      character.User = await this.usersService.GetUser();

      character = await this.characterRepository.AddAsync(character);

      return this.Ok(character.Id);
    }
  }
}
