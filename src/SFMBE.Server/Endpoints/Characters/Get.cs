namespace SFMBE.Server.Endpoints.Characters
{
  using System.Threading;
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data.Models;
  using SFMBE.Data.Repositories;
  using SFMBE.Data.Specifications.Characters;
  using SFMBE.Server.Repositories;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Characters.Queries;

  public class Get : BaseAsyncEndpoint<GetCharacterQueryResponse>
  {
    private readonly IAsyncRepository<Character> characterRepository;
    private readonly IUsersRepository usersRepository;

    public Get(IAsyncRepository<Character> repository, IUsersRepository usersRepository)
    {
      this.characterRepository = repository;
      this.usersRepository = usersRepository;
    }

    [Authorize]
    [HttpGet("api/Characters/Get")]
    public override async Task<ActionResult<GetCharacterQueryResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
      var userId = (await this.usersRepository.GetUser())?.Id;

      if (string.IsNullOrEmpty(userId))
      {
        return this.BadRequest("You're not log in.");
      }

      var spec = new GetCharacterSpecification(userId);
      var character = await this.characterRepository.FirstOrDefaultAsync(spec);

      if (character is null)
      {
        return this.BadRequest("Character not found");
      }

      return this.Ok(character.To<GetCharacterQueryResponse>());
    }
  }
}
