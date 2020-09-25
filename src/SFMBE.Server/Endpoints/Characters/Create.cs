namespace SFMBE.Server.Endpoints.Characters
{
  using System.Threading;
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data.Models;
  using SFMBE.Data.Repositories;
  using SFMBE.Server.Repositories;

  public class Create : BaseAsyncEndpoint<string, int>
  {
    private readonly IAsyncRepository<Character> characterRepository;
    private readonly IUsersRepository usersRepository;

    public Create(IAsyncRepository<Character> characterRepository, IUsersRepository usersRepository)
    {
      this.characterRepository = characterRepository;
      this.usersRepository = usersRepository;
    }

    [Authorize]
    [HttpPost("api/Characters/Create")]
    public override async Task<ActionResult<int>> HandleAsync([FromBody] string name, CancellationToken cancellationToken = default)
    {
      var character = new Character { Name = name };
      character.User = await this.usersRepository.GetUser();

      character = await this.characterRepository.AddAsync(character);

      return this.Ok(character.Id);
    }
  }
}
