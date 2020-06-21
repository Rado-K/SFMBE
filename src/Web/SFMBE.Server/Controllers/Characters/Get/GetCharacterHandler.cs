namespace SFMBE.Server.Controllers.Characters.Get
{
  using MediatR;
  using SFMBE.Services.Data.Character;
  using SFMBE.Shared;
  using SFMBE.Shared.Character.Get;
  using System.Threading;
  using System.Threading.Tasks;

  public class GetCharacterHandler : IRequestHandler<GetCharacterRequest, ApiResponse<GetCharacterResponse>>
  {
    private readonly ICharactersService charactersService;

    public GetCharacterHandler(ICharactersService charactersService)
    {
      this.charactersService = charactersService;
    }

    public async Task<ApiResponse<GetCharacterResponse>> Handle(GetCharacterRequest request, CancellationToken cancellationToken)
    {
      var response = await this.charactersService.GetCharacter<GetCharacterResponse>();

      return response.ToApiResponse();
    }
  }
}
