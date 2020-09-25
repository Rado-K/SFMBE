namespace SFMBE.Server.Endpoints.Characters
{
  using System.Threading.Tasks;
  using System.Threading;
  using Ardalis.ApiEndpoints;
  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data.Models;
  using SFMBE.Data.Repositories;
  using SFMBE.Services.Mapping;
  using SFMBE.Shared.Characters.Commands;

  public class Update : BaseAsyncEndpoint<UpdateCharacterCommand, UpdateCharacterCommand>
  {
    private readonly IAsyncRepository<Character> characterRepository;

    public Update(IAsyncRepository<Character> repository)
    {
      this.characterRepository = repository;
    }

    [Authorize]
    [HttpPut("api/Characters/Update")]
    public override async Task<ActionResult<UpdateCharacterCommand>> HandleAsync([FromBody] UpdateCharacterCommand request, CancellationToken cancellationToken = default)
    {
      var character = await this.characterRepository.GetByIdAsync(request.Id);
      MappingExtensions.To(request, character);
      await this.characterRepository.UpdateAsync(character);
      return this.Ok(request);
    }
  }
}