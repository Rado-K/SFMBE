﻿namespace SFMBE.Server.Endpoints.Characters
{
  using System.Threading;
  using System.Threading.Tasks;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Repositories;
  using SFMBE.Server.Repositories.Characters;

  public class Create : BaseAsyncEndpoint<string, int>
  {
    private readonly ICharactersRepository characterRepository;
    private readonly IUsersRepository usersRepository;

    public Create(ICharactersRepository characterRepository, IUsersRepository usersRepository)
    {
      this.characterRepository = characterRepository;
      this.usersRepository = usersRepository;
    }

    [Authorize]
    [HttpPost("api/Characters/Create")]
    public override async Task<ActionResult<int>> HandleAsync([FromBody] string name, CancellationToken cancellationToken = default)
    {
      var characterId = await this.characterRepository.Create(name);

      if (!characterId.HasValue)
      {
        this.BadRequest();
      }

      return this.Ok(characterId.Value);
    }
  }
}
