namespace SFMBE.Server.Controllers.Characters.Update
{
  using MediatR;
  using SFMBE.Services.Data.Character;
  using SFMBE.Shared;
  using SFMBE.Shared.Character.Update;
  using System.Threading;
  using System.Threading.Tasks;

  public class UpdateCharacterHandler : IRequestHandler<UpdateCharacter, ApiResponse<UpdateCharacter>>
  {
    private readonly ICharactersService charactersService;

    public UpdateCharacterHandler(ICharactersService charactersService)
    {
      this.charactersService = charactersService;
    }

    public async Task<ApiResponse<UpdateCharacter>> Handle(UpdateCharacter request, CancellationToken cancellationToken)
    {
      var response = await this.charactersService.UpdateCharacter(request);

      return response.ToApiResponse();
    }
  }
}
