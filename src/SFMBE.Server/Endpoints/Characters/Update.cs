namespace SFMBE.Server.Endpoints.Characters
{
  using System.Threading.Tasks;
  using System.Threading;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Repositories.Characters;
  using SFMBE.Shared.Characters.Commands;

  public class Update : BaseAsyncEndpoint<UpdateCharacterCommand, UpdateCharacterCommand>
  {
    private readonly ICharactersRepository characterRepository;

    public Update(ICharactersRepository characterRepository)
    {
      this.characterRepository = characterRepository;
    }

    [Authorize]
    [HttpPut("api/Characters/Update")]
    public override async Task<ActionResult<UpdateCharacterCommand>> HandleAsync([FromBody] UpdateCharacterCommand request, CancellationToken cancellationToken = default)
    {
      var character = await this.characterRepository.Update(request);

      return this.Ok(character);
    }
  }
}