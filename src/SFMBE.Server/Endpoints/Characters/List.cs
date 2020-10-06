namespace SFMBE.Server.Endpoints.Characters
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using System.Threading;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Repositories.Characters;
  using SFMBE.Shared.Characters.Queries;

  public class List : BaseAsyncEndpoint<string, IEnumerable<ListCharactersQueryResponse>>
  {
    private readonly ICharactersRepository charactersRepository;

    public List(ICharactersRepository charactersRepository)
    {
      this.charactersRepository = charactersRepository;
    }

    [Authorize]
    [HttpGet("api/Characters/GetList/{parameter}")]
    public override async Task<ActionResult<IEnumerable<ListCharactersQueryResponse>>> HandleAsync(string parameter, CancellationToken cancellationToken = default)
    {
      var characters = await this.charactersRepository.GetList(parameter);

      return this.Ok(characters);
    }
  }
}