namespace SFMBE.Server.Endpoints.Characters
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data.Models;
  using SFMBE.Data.Repositories;
  using SFMBE.Data.Specifications.Characters;
  using SFMBE.Shared.Characters.Queries;

  public class List : BaseAsyncEndpoint<string, IEnumerable<ListCharactersQueryResponse>>
  {
    private readonly IAsyncRepository<Character> repository;

    public List(IAsyncRepository<Character> repository)
    {
      this.repository = repository;
    }

    [Authorize]
    [HttpGet("api/Characters/GetList/{parameter}")]
    public override async Task<ActionResult<IEnumerable<ListCharactersQueryResponse>>> HandleAsync(string parameter, CancellationToken cancellationToken = default)
    {
      var spec = new ListCharactersSpecification(parameter);
      var characters = (await this.repository
        .ListAsync(spec)).Select(ListCharactersQueryResponse.FromCharacter);

      return this.Ok(characters);
    }
  }
}
