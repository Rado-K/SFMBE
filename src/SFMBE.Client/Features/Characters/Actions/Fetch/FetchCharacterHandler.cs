namespace SFMBE.Client.Features.Characters
{
  using BlazorState;
  using MediatR;
  using SFMBE.Client.Features.Base;
  using SFMBE.Client.Infrastructure.Http;
  using SFMBE.Shared.Characters.Queries;
  using System.Threading;
  using System.Threading.Tasks;

  internal partial class CharactersState
  {
    internal class FetchCharacterHandler : BaseHandler<FetchCharacterAction>
    {
      private readonly IHttpService httpService;

      public FetchCharacterHandler(IHttpService httpService, IStore store) : base(store)
      {
        this.httpService = httpService;
      }

      public override async Task<Unit> Handle(FetchCharacterAction action, CancellationToken cancellationToken)
      {
        var character = await this.httpService.GetJson<GetCharacterQueryResponse>("api/Characters/Get");
        // var character = await this.charactersRepository.GetCharacter(action.CharacterId);

        this.CharacterState.Character = character.Data;
        this.BagsState.Bag = this.CharacterState.Character.Bag;
        this.GearsState.Gear = this.CharacterState.Character.Gear;

        return await Unit.Task;
      }
    }
  }
}
