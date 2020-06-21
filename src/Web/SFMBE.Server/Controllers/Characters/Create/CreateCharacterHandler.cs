namespace SFMBE.Server.Controllers.Characters.Create
{
  using MediatR;
  using SFMBE.Services.Data.Character;
  using SFMBE.Shared;
  using SFMBE.Shared.Character.Create;
  using System.Threading;
  using System.Threading.Tasks;

  public class CreateCharacterHandler : IRequestHandler<CreateCharacterRequest, ApiResponse<CreateCharacterResponse>>
  {
    private readonly ICharactersService charactersService;

    public CreateCharacterHandler(ICharactersService charactersService)
    {
      this.charactersService = charactersService;
    }

    public async Task<ApiResponse<CreateCharacterResponse>> Handle(CreateCharacterRequest request, CancellationToken cancellationToken)
    {
      var response = await this.charactersService.CreateCharacter(request.Name);

      return response.ToApiResponse();
    }
  }
}
