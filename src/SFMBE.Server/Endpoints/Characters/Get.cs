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
  using SFMBE.Server.Repositories.Characters;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Characters.Queries;

  public class Get : BaseAsyncEndpoint<GetCharacterQueryResponse>
  {
    private readonly ICharactersRepository characterRepository;

    public Get(ICharactersRepository characterRepository)
    {
      this.characterRepository = characterRepository;
    }

    [Authorize]
    [HttpGet("api/Characters/Get")]
    public override async Task<ActionResult<GetCharacterQueryResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
      (GetCharacterQueryResponse character, string message) = await this.characterRepository.Get();

      if (character is null)
      {
        return this.BadRequest(message);
      }

      return this.Ok(character);
    }
  }
}
